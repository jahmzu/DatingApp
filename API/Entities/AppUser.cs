// namespace should be named after the folder the class (.cs) is in
using System.ComponentModel.DataAnnotations;

namespace API.Entities;
public class AppUser
{
    //convention to use Id for name. Entity recognizes this
    public int Id{get; set;}
    public string UserName{get;set;}
}
