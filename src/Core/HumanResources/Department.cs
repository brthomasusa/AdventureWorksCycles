#pragma warning disable CS8618

using AWC.Core.HumanResources.ValueObjects;
using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.HumanResources
{
    public sealed class Department : Entity<int>
    {
        private Department
        (
            int id,
            OrganizationName name,
            OrganizationName groupName
        )
        {
            Id = id;
            Name = name;
            GroupName = groupName;
        }

        internal static Result<Department> Create(int id, string name, string groupName)
        {
            try
            {
                Department dept = new
                (
                    id,
                    OrganizationName.Create(name),
                    OrganizationName.Create(groupName)
                );

                return dept;
            }
            catch (Exception ex)
            {
                return Result<Department>.Failure<Department>(new Error("Department.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        internal Result<Department> Update(string name, string groupName)
        {
            try
            {
                Name = OrganizationName.Create(name);
                GroupName = OrganizationName.Create(groupName);
                UpdateModifiedDate();

                return this;
            }
            catch (Exception ex)
            {
                return Result<Department>.Failure<Department>(new Error("Department.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public OrganizationName Name { get; private set; }

        public OrganizationName GroupName { get; private set; }
    }
}