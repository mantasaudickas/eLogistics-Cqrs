using System;

namespace SimpleCQRSCodeGenerator
{
    public enum ClassType
    {
        Command,
        Event,
        Handler,
        State,
        ViewBase,
        View,
        Dto,
        Message,
        ReadModelFacade,
    }
}
