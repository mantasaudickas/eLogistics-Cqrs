using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using eLogistics.Application.CQRS.Interfaces.Dto;
using eLogistics.Application.UI.Domain;

namespace eLogistics.Executable.Controllers
{
    public abstract class ListViewController<TModel, TDto>
        where TModel : EditModel<TDto>
        where TDto : DataTransferObject, new()
    {
        #region Private Fields

        private readonly ListView _listBox;
        private readonly ObservableCollection<TModel> _listBoxItems = new ObservableCollection<TModel>();

        #endregion

        #region Constructor

        protected ListViewController(ListView listBox)
        {
            _listBox = listBox;
        }

        #endregion

        #region Properties

        public IList<TModel> ListBoxItems
        {
            get { return _listBoxItems; }
        }

        #endregion

        #region Init

        public void Init()
        {
            this._listBox.KeyDown += (sender, args) => HandleListItemsKeys(args);
            this._listBox.MouseDoubleClick += (sender, args) => HandleListItemsDoubleClick(args);

            var list = GetList() ?? new List<TDto>();

            foreach (TDto dto in list)
            {
                TModel model = this.CreateModel(dto);
                _listBoxItems.Add(model);
            }
        }

        #endregion

        #region Add / Edit / Remove

        public void AddModel()
        {
            TModel editModel = this.CreateModel();
            if (this.Edit(editModel, false))
            {
                editModel.Commit();

                _listBoxItems.Add(editModel);
                _listBox.SelectedItem = editModel;
            }
        }

        public void EditModel()
        {
            TModel editModel = (TModel) _listBox.SelectedItem;
            if (editModel != null)
            {
                TDto clone = editModel.CloneDto();
                if (this.Edit(editModel, true))
                {
                    editModel.Commit();
                }
                else if (editModel.HasChanges)
                {
                    TModel clonedModel = CreateModel(clone);

                    int index = _listBoxItems.IndexOf(editModel);
                    _listBoxItems.RemoveAt(index);
                    _listBoxItems.Insert(index, clonedModel);
                    _listBox.SelectedItem = clonedModel;
                }
            }
        }

        public void RemoveModel()
        {
            TModel editModel = (TModel) _listBox.SelectedItem;
            if (editModel != null)
            {
                editModel.Delete();
                editModel.Commit();
                _listBoxItems.Remove(editModel);
            }
        }

        #endregion

        #region Edit Model

        private bool Edit(TModel editModel, bool modelEdit)
        {
            Window window = this.CreateEditWindow(modelEdit);
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowInTaskbar = false;
            window.DataContext = editModel;
            return window.ShowDialog().GetValueOrDefault();
        }

        #endregion

        #region Event Handlers

        private void HandleListItemsKeys(KeyEventArgs args)
        {
            if (args.Key == Key.Insert)
            {
                this.AddModel();
            }
            else if (args.Key == Key.Enter)
            {
                this.EditModel();
            }
        }

        private void HandleListItemsDoubleClick(MouseButtonEventArgs args)
        {
            EditModel();
        }

        #endregion

        #region Abstract Members

        protected abstract TModel CreateModel(TDto dto = null);
        protected abstract IList<TDto> GetList(string filter = null);
        protected abstract Window CreateEditWindow(bool modelEdit);

        #endregion
    }
}
