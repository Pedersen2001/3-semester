using F_Klub_Stregsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F_Klub_Stregsystem.Classes
{
    public class IdProvider : IIdProvider
	{
		List<int> _usedIds = new() { 0 };

		public int NextId()
		{
			_usedIds.Add(_usedIds.Max() + 1);
			return _usedIds.Max() + 1;
		}

		public int TryId(int id)
		{
			if (_usedIds.Contains(id))
				throw new ArgumentException();

			return id;
		}
	}
}