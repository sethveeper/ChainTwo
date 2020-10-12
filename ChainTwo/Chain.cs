/*
    Author: Dominic "Seth" Jones-Jackson (F)
    E-mail: sethveeper@gmail.com
    
    Initialized on: October 1, 2020
    
 */

using System;
using System.Collections.Generic;

namespace ChainTwo
{
    public class Chain<T>
    {
        #region Properties

        private Link<T> head;
        private Link<T> foot;
        private Link<T> selected;
        private int length;
        // End of Properties

        public Link<T> Head { get => head; set => head = value; }
        public Link<T> Foot { get => foot; set => foot = value; }
        public Link<T> Selected { get => selected; set => selected = value; }
        public int Length { get => length; set => length = value; }

        // End of Get/Set-ers

        #endregion
        // End of Properties

        #region Constructors

        public Chain()
        {
            this.head = null;
            this.foot = null;
            this.selected = null;
            this.length = 0;
        }
        // End of Default Constructor

        public Chain(T[] array)
        {
            this.head = null;
            this.foot = null;
            this.selected = null;
            this.length = 0;

            foreach(T item in array)
            {
                this.Add(item);
            }
        }
        // End of Array constructor

        #endregion
        // End of Constructors

        #region Methods

        public void Add(T value)
        { // Adds a new link.

            Link<T> newLink = new Link<T>(value);
            // Here's the new link in question!

            if (this.head == null)
            { // First, we'll check to see if the list is empty.
                this.head = newLink;
                this.foot = newLink;
                this.selected = newLink;
                // As it happens, newLink is already in the right shape for this!
            }
            // End of If (No existing links) block
            else
            { // If it's not, then we just add it onto the end.

                newLink.Index = this.length;
                // Keep track of where in the list it is...
                this.foot.Next = newLink;
                newLink.Prev = this.foot;
                // Have the old foot point to the new foot, and vice versa...
                this.foot = newLink;
                // Then, replace the old foot with the new foot.
            }
            // End of Else (Links exist) block

            this.length++;
            // Gotta keep track of the total, ideally!
        }
        // End of Add(value) method

        public bool Iter(bool direct = true)
        {
            bool exit = false;
            // Returns true or false to indicate that we've reached one of the ends.
            // "False" is the default, indicating that we're in the "middle" somewhere.
            // "True" is passed instead if it attempts to go too far.

            // Moves the selected link "up" or "down" by one(1) place.
            // direct = "true" means count towards the foot. 
            // direct = "false" means count towards the head.
            if (direct)
            {
                if (this.selected.Next != null)
                    // If there's a next link to go to...
                    this.selected = this.selected.Next;
                else
                { // If there's not...
                    this.selected = this.foot;
                    exit = true;
                }
            }
            else
            {
                if (this.selected.Prev != null)
                    // If there's a previous link to go to...
                    this.selected = this.selected.Prev;
                else
                { // If there's not...
                    this.selected = this.head;
                    exit = true;
                }
            }
            // End of If/Else (Direction) block

            return exit;
        }
        // End of Iteration("up"/"down") method

        public T Select(int index = 0)
        { // Moves the "selector" to the appropriate index.
            // As a convenience, it returns the value stored in that index.

            if (index <= 0)
            { // If we want the "head" of the list...
                this.selected = this.head;
            }
            // End of If(head) block
            else if (index >= this.length)
            { // If we want the foot...
                this.selected = this.foot;
                // May need *some* improvement??
            }
            // End of Else If(foot) block
            else
            { // If we need to search for it...

                int half = this.length / 2;
                // We'll grab the "midway" point in the list first.
                int distance = index - this.selected.Index;
                // Then, we'll get the distance between the current and desired index.
                bool direct = true;
                // "True" means count towards the foot 
                // "false" means count towards the head

                if (half < distance || half < (distance * -1))
                { // If the current index is further than the head or foot is...
                    if (index < half)
                    { // If our desired index is in the "head" half...
                        this.selected = this.head;
                        direct = true;
                    }
                    else
                    { // If our desired index is in the "foot" half...
                        this.selected = this.foot;
                        direct = false;
                    }
                    // End of If/Else (Direction) block
                }
                // End of If(Start at ends) block
                else
                {
                    if (this.selected.Index < index)
                    { // If we're "before" the index...
                        direct = true;
                    }
                    else
                    { // If we're "past" the index...
                        direct = false;
                    }
                }
                // End of Else(Start where you are) block


                // Now we're ready to actually find it!
                while (this.selected.Index != index)
                {
                    // Reminder:
                    // "True" means count towards the foot 
                    // "false" means count towards the head
                    this.Iter(direct);
                }
                // End of while (Searching) block
            }
            // End of Else(Searching) block


            return this.selected.Value;
        }
        // End of Select(index) method

        public T[] ToArray()
        { // Used to convert a Chain into a standard array.

            T[] output = new T[this.length];
            // The output array.

            int selectSave = this.selected.Index;
            // Saving the previous index so that we can return to it in a moment.
            // (Although, I wonder if it's really necessary...)

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = this.Select(i);
            }
            // End of For loop (Reassignment)

            this.Select(selectSave);
            // Put that Selector back, OR SO HELP ME...

            return output;
        }
        // End of ToArray method

        #endregion
        // End of Methods
    }
    // End of Chain class
}
// End of namespace