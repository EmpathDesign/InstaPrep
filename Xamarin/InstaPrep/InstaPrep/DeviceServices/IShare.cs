using System;
using System.Threading.Tasks;

namespace InstaPrep.DeviceServices
{
	public interface IShare
	{
        Task Show(string title, string message, string filePath);
    }
}

