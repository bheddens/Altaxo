using System;

namespace Altaxo.Collections
{
	/// <summary>
	/// This class represents a simple integer range specified by start and count, that can be used as a lightweight substitute for a <see>IndexSelection</see> if 
	/// the selection is contiguous.
	/// </summary>
	public class IntegerRangeAsCollection : IAscendingIntegerCollection
	{
		/// <summary>
		/// The starting point of the integer range.
		/// </summary>
		int _start;

		/// <summary>
		/// The width of the integer range. The range is from <code>_start</code> until (including) <code>_start + _count-1</code>. 
		/// </summary>
		int _count;

		/// <summary>
		/// Constructs the range by giving a start and the width.
		/// </summary>
		/// <param name="start">The range start.</param>
		/// <param name="count">The range width, i.e the range is from start until (including) start+count-1.</param>
		public IntegerRangeAsCollection(int start, int count)
		{
			_start = start;
			_count = count;
		}

		/// <summary>
		/// The width of the range.
		/// </summary>
		public int Count 
		{
			get 
			{
				return _count;
			}
		}

		/// <summary>
		/// Returns the i-th number of the range, starting from the start of the range.
		/// </summary>
		public int this[int i]
		{
			get { return _start + i; }
		}

		/// <summary>
		/// Returns true, if the integer <code>nValue</code> is contained in this collection.
		/// </summary>
		/// <param name="nValue">The integer value to test for membership.</param>
		/// <returns>True if the integer value is member of the collection.</returns>
		public bool Contains(int nValue)
		{
			return nValue>=_start && nValue<(_start+_count);
		}


		/// <summary>
		/// Get the next range (i.e. a contiguous range of integers) in ascending order.
		/// </summary>
		/// <param name="currentposition">The current position into this collection. Use 0 for the first time. On return, this is the next position.</param>
		/// <param name="rangestart">Returns the starting index of the contiguous range.</param>
		/// <param name="rangecount">Returns the width of the range.</param>
		/// <returns>True if the returned data are valid, false if there is no more data.</returns>
		/// <remarks>You can use this function in a while loop:
		/// <code>
		/// int rangestart, rangecount;
		/// int currentPosition=0;
		/// while(GetNextRangeAscending(ref currentPosition, out rangestart, out rangecount))
		///		{
		///		// do your things here
		///		}
		/// </code></remarks>
		public bool GetNextRangeAscending(ref int currentposition, ref int rangestart, ref int rangecount)
		{
			if(currentposition<0 || currentposition>=Count)
			{
				return false;
			}
			else
			{
				rangestart = _start + currentposition;
				rangecount = _start + _count - rangestart;
				currentposition = _count;
				return true;
			}
		}

		/// <summary>
		/// Get the next range (i.e. a contiguous range of integers) in descending order.
		/// </summary>
		/// <param name="currentposition">The current position into this collection. Use Count-1 for the first time. On return, this is the next position.</param>
		/// <param name="rangestart">Returns the starting index of the contiguous range.</param>
		/// <param name="rangecount">Returns the width of the range.</param>
		/// <returns>True if the range data are valid, false if there is no more data. Used as end-of-loop indicator.</returns>
		/// <remarks>You can use this function in a while loop:
		/// <code>
		/// int rangestart, rangecount;
		/// int currentPosition=selection.Count-1;
		/// while(selection.GetNextRangeAscending(currentPosition,out rangestart, out rangecount))
		///		{
		///		// do your things here
		///		}
		/// </code></remarks>
		public bool GetNextRangeDescending(ref int currentposition, ref int rangestart, ref int rangecount)
		{
			if(currentposition<0 || currentposition>=Count)
			{
				return false;
			}
			else
			{
				rangestart = _start;
				rangecount = currentposition+1;
				currentposition = -1;
				return true;
			}
		}
	}
}
