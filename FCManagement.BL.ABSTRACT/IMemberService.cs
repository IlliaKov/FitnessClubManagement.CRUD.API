using FCManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCManagement.BL.ABSTRACT
{
    public interface IMemberService
    {
        void AddObject(MemberDTO member);
        void DeleteObject(int id);
        IEnumerable<MemberDTO> GetAll();
        MemberDTO GetElementById(int id);
        void UpdateObject(MemberDTO member);
    }
}
