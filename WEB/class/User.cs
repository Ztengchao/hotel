using System;

namespace WEB.@class
{
	[Serializable]
	public class User //用户类
	{
		/// <summary>
		/// 用户名
		/// </summary>
		public string Username { get; set; }
		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// 昵称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 电话
		/// </summary>
		public string Phone { get; set; }
	}
}