using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Common
{
    /// <summary>
    /// Etiketlemek icin kullanilan bir yapi
    /// Idenity nin kendi userName alani var servisleride var 
    /// IEntityBase CreatedDate gidib bir user class i uzerinde ekleyemem
    /// Userlar icin biz bunlari GUID olarak tutacagiz
    /// Repostory unitwork kullanirken 
    /// </summary>
    public interface IEntityBase
    {

    }
}
