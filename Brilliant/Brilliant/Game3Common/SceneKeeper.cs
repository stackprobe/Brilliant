using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;

namespace Charlotte.Game3Common
{
	public class SceneKeeper
	{
		private int FrameMax;
		private int StartedProcFrame = -1;

		public SceneKeeper(int frameMax)
		{
			if (frameMax < 1 || IntTools.IMAX < frameMax)
				throw new DDError();

			this.FrameMax = frameMax;
		}

		public void Fire()
		{
			this.StartedProcFrame = DDEngine.ProcFrame;
		}

		public void Clear()
		{
			this.StartedProcFrame = -1;
		}

		public bool IsJustFired()
		{
			return this.StartedProcFrame == DDEngine.ProcFrame;
		}

		public bool IsFlaming()
		{
			return this.StartedProcFrame != -1 && (DDEngine.ProcFrame - this.StartedProcFrame) <= this.FrameMax;
		}

		public int Count
		{
			get
			{
				return this.StartedProcFrame == -1 ? -1 : DDEngine.ProcFrame - this.StartedProcFrame;
			}
		}

		public DDScene GetScene()
		{
			if (this.StartedProcFrame != -1)
			{
				int count = DDEngine.ProcFrame - this.StartedProcFrame;

				if (count <= this.FrameMax)
				{
					return new DDScene()
					{
						Numer = count,
						Denom = this.FrameMax,
						Rate = count / (double)this.FrameMax,
					};
				}
				this.StartedProcFrame = -1;
			}
			return null;
		}
	}
}
