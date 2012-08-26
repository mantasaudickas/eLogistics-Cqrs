eLogistics-Cqrs
===============

This project should be small stock management tool where user can enter his own suppliers, customers, articles, 
make orders and print invoices. It is supposed to work from USB stick.

Implementation is done using CQRS (inspired by Greg Young and Rinat Abdulin crash course in Vilnius)
	- http://en.wikipedia.org/wiki/Command-query_separation
	- http://martinfowler.com/bliki/CQRS.html
	- http://elegantcode.com/2009/11/11/cqrs-la-greg-young/
	- http://lokad.github.com/lokad-cqrs/
	- http://abdullin.com/cqrs/

Project does not have real database. Uses file system as a storage. 
Since it should be single user application should not be a problem.

Currently it is single executable, however implementation done so that would be easy to cross 
system boundaries (by doing service calls).

Project UI uses components from Infragistics. 
Since it is not free in future UI will be implemented using WPF.
