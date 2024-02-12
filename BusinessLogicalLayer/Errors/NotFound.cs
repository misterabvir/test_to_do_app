using BusinessLogicalLayer.Base;
using System;

namespace BusinessLogicalLayer.Errors
{
    public class NotFound : Error
    {
        public NotFound(int id)
            : base(
                  code: Code.NotFound,
                  message: "TaskEntity.NotFound",
                  description: $"TaskEntity with id {id} not found in database")
        { }
    }

    public class AlreadyExist : Error
    {
        public AlreadyExist(string name)
            : base(
                  code: Code.Conflict,
                  message: "TaskEntity.AlreadyExist",
                  description: $"TaskEntity with the same name {name} already exist database")
        { }
    }



    public class AlreadyResolve : Error
    {
        public AlreadyResolve(string name)
            : base(
                  code: Code.Conflict,
                  message: "TaskEntity.AlreadyResolve",
                  description: $"TaskEntity with name {name} already resolve")
        { }
    }
}
