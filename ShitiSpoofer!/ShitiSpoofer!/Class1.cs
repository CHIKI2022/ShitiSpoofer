using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System.Windows.Forms;

namespace ShitiFivemSpoofer_
{
	internal class Helpers
	{
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public static Random rand = new Random();


		public const string Alphabet = "ABCDEF0123456789";


		public static Random random = new Random();


		public const string Alphabet1 = "abcdef0123456789";

		public static string GenerateString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "ABCDEF0123456789"[Helpers.rand.Next("ABCDEF0123456789".Length)];
			}
			return new string(array);
		}

		public static void SpoofMacAddress()
		{
			string value = "00" + Helpers.GenerateString(10);
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
			registryKey.SetValue("NetworkAddress", value);
			registryKey.Close();
		}


		public static string CurrentMAC()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
			string result = (string)registryKey.GetValue("NetworkAddress");
			registryKey.Close();
			return result;
		}

		public static void SpoofGUID()
		{
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
		}


		public static string CurrentGUID()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		public static void SpoofProductID()
		{
			string value = string.Concat(new string[]
			{
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5)
			});
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("ProductID", value);
			registryKey.Close();
		}

		public static string CurrentProductID()
		{
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string text2 = "ProductID";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}


		public static void SpoofHwProfileGUID()
		{
			string value = "{" + Guid.NewGuid().ToString() + "}";
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
			registryKey.SetValue("HwProfileGUID", value);
			registryKey.Close();
		}

		public static string CurrentHwProfileGUID()
		{
			string text = "SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string text2 = "HwProfileGUID";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		public static bool Strncmp(string str, byte[] data, int offset)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (data[i + offset] != (byte)str[i])
				{
					return false;
				}
			}
			return true;
		}

		public static void SpoofPCName()
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
			registryKey.SetValue("ComputerName", "DESKTOP-" + Helpers.GenerateString(15));
			registryKey.Close();
		}

		public static string CurrentPCName()
		{
			string text = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
			string text2 = "ComputerName";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}




		private class Disk : IDisposable
		{
			public Disk(char volume)
			{
				IntPtr preexistingHandle = Helpers.Disk.CreateFile(string.Format("\\\\.\\{0}:", volume), FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
				this.handle = new SafeFileHandle(preexistingHandle, true);
				if (this.handle.IsInvalid)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}

			public void ReadSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (Helpers.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Helpers.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!Helpers.Disk.ReadFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}

			public void WriteSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (Helpers.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Helpers.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!Helpers.Disk.WriteFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}


			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}


			protected virtual void Dispose(bool disposing)
			{
				if (disposing && this.handle != null)
				{
					this.handle.Dispose();
				}
			}


			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);


			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern uint SetFilePointer([In] SafeFileHandle hFile, [In] uint lDistanceToMove, [In] IntPtr lpDistanceToMoveHigh, [In] Helpers.Disk.EMoveMethod dwMoveMethod);


			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool ReadFile(SafeFileHandle hFile, [Out] byte[] lpBuffer, int nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);


			[DllImport("kernel32.dll")]
			private static extern bool WriteFile(SafeFileHandle hFile, [In] byte[] lpBuffer, int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped);


			private SafeFileHandle handle;


			private const uint INVALID_SET_FILE_POINTER = 4294967295U;


			private enum EMoveMethod : uint
			{
				Begin,
				Current,
				End
			}

		}
	}
}

