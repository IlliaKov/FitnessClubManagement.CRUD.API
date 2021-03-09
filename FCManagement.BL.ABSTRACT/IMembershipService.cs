using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.BL.ABSTRACT
{
    public interface IMembershipService
    {
        void AddObject(MembershipDTO membership);
        void DeleteObject(int id);
        IEnumerable<MembershipDTO> GetAll();
        MembershipDTO GetElementById(int id);
        void UpdateObject(MembershipDTO membership);
    }
}
