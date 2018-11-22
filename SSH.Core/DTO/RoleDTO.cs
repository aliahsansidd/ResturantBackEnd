using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;

namespace SSH.Core.DTO
{
    public class RoleDTO : DTO<ApplicationRole, string>
    {
        public string Name { get; set; }

        public List<PermissionDTO> Permissions { get; set; }

        public List<UserRolePermissionDTO> UserRolePermissions { get; set; }

        public override void ConvertFromEntity(ApplicationRole entity)
        {
            base.ConvertFromEntity(entity);

            this.Id = entity.Id;
            this.Name = entity.Name;

            if (entity.UserRolePermission != null && entity.UserRolePermission.Count() > 0)
            {
                this.Permissions = new List<PermissionDTO>();
                this.UserRolePermissions = new List<UserRolePermissionDTO>();
                foreach (var item in entity.UserRolePermission)
                {
                    this.UserRolePermissions.Add(new UserRolePermissionDTO { Id = item.Id, PermissionId = item.PermissionID, RoleId = item.RoleID });
                    this.Permissions.Add(new PermissionDTO { Id = item.PermissionID, Name = item.Permission.Name });
                }
            }
        }

        public override ApplicationRole ConvertToEntity(ApplicationRole entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;

            return entity;
        }
    }
}
