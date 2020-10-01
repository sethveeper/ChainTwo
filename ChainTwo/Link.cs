/*
    Author: Dominic "Seth" Jones-Jackson (F)
    E-mail: sethveeper@gmail.com
    
    Initialized on: October 1, 2020
    
 */

using System;
using System.Collections.Generic;
using System.Text;
// End of using statements

namespace ChainTwo
{
    public class Link<T>
    {
        #region Properties
        private T value;
        private Link<T> next;
        private Link<T> prev;
        private int index;

        public T Value { get => value; set => this.value = value; }
        public Link<T> Next { get => next; set => next = value; }
        public Link<T> Prev { get => prev; set => prev = value; }
        public int Index { get => index; set => index = value; }

        #endregion
        // End of Properties

        #region Constructors
        public Link(T value, Link<T> next, Link<T> prev, int index)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
            this.index = index;
        }
        // End of Full Constructor

        public Link(T value, Link<T> prev)
        {
            this.Value = value;
            this.Next = null;
            this.Prev = prev;
        }
        // End of New Link Constructor

        public Link(T value)
        {
            this.value = value;
            this.next = null;
            this.prev = null;
            this.index = 0;
        }
        // End of Value Constructor

        #endregion
        // End of Constructors

        #region Methods

        public override string ToString()
        {
            return this.value.ToString();
        }
        // End of ToString method

        #endregion
        // End of Methods
    }
    // End of Link class
}
// End of namespace