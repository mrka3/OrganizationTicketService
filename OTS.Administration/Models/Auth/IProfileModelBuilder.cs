using System;

namespace OTS.Administration.Models.Auth
{
    public interface IProfileModelBuilder
    {
        ProfileModel Build(Guid id);
    }
}