using UnityEngine;

namespace Haru.Client.Helpers
{
    public class HookHelper
    {
        private const string _name = "Haru";
        public static GameObject Object
		{
			get
			{
				var o = GameObject.Find(_name);

				if (o == null)
                {
					o = new GameObject(_name);
				    UnityEngine.Object.DontDestroyOnLoad(o);
                }

				return o;
			}
		}
    }
}