using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebExample1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "GetData")]
        public IActionResult GetData()
        {
           
            int size = 200 * 1024 * 1024;
            nint ptr = Marshal.AllocHGlobal(size);
            
            for (int i = 0; i < size; i++)
            {
                Marshal.WriteByte(ptr, i, (byte)'F');
            }

            string str = Marshal.PtrToStringUTF8(ptr, size);
            Marshal.FreeHGlobal(ptr);

            return Ok(str);
        }
    }
}
