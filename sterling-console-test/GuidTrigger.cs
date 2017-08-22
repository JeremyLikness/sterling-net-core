using System;
using Sterling.Core.Database;

namespace Sterling.CmdLine.Test
{
    public class GuidTrigger<T>: BaseSterlingTrigger<T, Guid> where T: CoolColor, new()
    {
        public override bool BeforeSave(T instance)
        {
            if (instance.Id == null || instance.Id == Guid.Empty)
            {
                instance.Id = Guid.NewGuid();
            }
            return true;
        }

        public override void AfterSave(T instance)
        {
            return;
        }

        public override bool BeforeDelete(Guid key)
        {
            return false;
        }
    }
}