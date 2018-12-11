namespace WEB.Class
{
	public class User //用户类
	{
		public User(string username ="", string password = "", string name = "", string phone = "")
		{
			Username = username;
			Password = password;
			Name = name;
			Phone = phone;
		}

		public string Username { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
	}
}