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
		private int StartedProcFrame = int.MaxValue;

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

		public void FireDelay(int delay = 1)
		{
			if (delay < 0 || IntTools.IMAX < delay)
				throw new DDError();

			this.StartedProcFrame = DDEngine.ProcFrame + delay;
		}

		public void Clear()
		{
			this.StartedProcFrame = int.MaxValue;
		}

		public bool IsJustFired()
		{
			return this.StartedProcFrame == DDEngine.ProcFrame;
		}

		public bool IsFlaming()
		{
			return this.StartedProcFrame <= DDEngine.ProcFrame && DDEngine.ProcFrame <= this.StartedProcFrame + this.FrameMax;
		}

		public int Count
		{
			get
			{
				return this.IsFlaming() ? DDEngine.ProcFrame - this.StartedProcFrame : -1;
			}
		}

		public DDScene GetScene()
		{
			if (this.IsFlaming())
			{
				int count = DDEngine.ProcFrame - this.StartedProcFrame;

				return new DDScene()
				{
					Numer = count,
					Denom = this.FrameMax,
					Rate = count / (double)this.FrameMax,
				};
			}
			return null;
		}
	}
}
