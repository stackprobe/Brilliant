using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Game3Common;
using Charlotte.Common;

namespace Charlotte.Tests.Game3Common
{
	public class CResourceTest
	{
		public void Test01()
		{
			for (; ; )
			{
				DDCurtain.DrawCurtain();

				DDDraw.DrawSimple(CResource.GetPicture(@"CResource\Picture\Picture0001.png"), 0, 0);
				DDDraw.DrawSimple(CResource.GetPicture(@"CResource\Picture\Picture0002.png"), 200, 0);
				DDDraw.DrawSimple(CResource.GetPicture(@"CResource\Picture\Picture0003.png"), 400, 0);

				DDEngine.EachFrame();
			}
		}
	}
}
