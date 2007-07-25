
using System;
using System.Text;

using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace netTiers.Petshop.Entities
{
   /// <summary>
   /// A generic collection for the nettiers entities that are generated from views. 
   /// Supports filtering, databinding, searching and sorting.
   /// </summary>
   [Serializable]
   public class VList<T> : ListBase<T>
   {

      /// <summary>
      /// Initializes a new instance of the <see cref="T:VList{T}"/> class.
      /// </summary>
      public VList()
      {
      }

      #region BindingList overrides

      /// <summary>
      /// Inserts the specified item in the list at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index where the item is to be inserted.</param>
      /// <param name="item">The item to insert in the list.</param>
      protected override void InsertItem(int index, T item)
      {
         base.InsertItem(index, item);
      }

      /// <summary>
      /// Removes the item at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove.</param>
      protected override void RemoveItem(int index)
      {
         base.RemoveItem(index);
      }

      #endregion

      #region ICloneable

      ///<summary>
      /// Creates an exact copy of this VList{T} instance.
      ///</summary>
      ///<returns>The VList{T} object this method creates, cast as an object.</returns>
      ///<implements><see cref="ICloneable.Clone"/></implements>
      public override object Clone()
      {
         return this.Copy();
      }

      ///<summary>
      /// Creates an exact copy of this VList{T} object.
      ///</summary>
      ///<returns>A new, identical copy of the VList{T}.</returns>
      public virtual VList<T> Copy()
      {
         VList<T> copy = new VList<T>();
         foreach (T item in this)
         {
            T itemCopy = (T)MakeCopyOf(item);
            copy.Add(itemCopy);
         }
         return copy;
      }
      #endregion ICloneable

      #region Added Functionality

      /// <summary>
      /// Performs the specified action on each element of the specified array.
      /// </summary>
      /// <param name="list">The list.</param>
      /// <param name="action">The action.</param>
      public static void ForEach<U>(VList<U> list, Action<U> action)
      {
         list.ForEach(action);
      }     

      #endregion	Added Functionality

      #region Find

      ///<summary>
      /// Finds a collection of objects in the current list matching the search criteria.
      ///</summary>
      /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
      /// <param name="value">Value to find.</param>
      public virtual VList<T> FindAll(System.Enum column, object value)
      {
         return FindAll(column.ToString(), value, true);
      }

      ///<summary>
      /// Finds a collection of objects in the current list matching the search criteria.
      ///</summary>
      /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
      /// <param name="value">Value to find.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      public virtual VList<T> FindAll(System.Enum column, object value, bool ignoreCase)
      {
         return FindAll(column.ToString(), value, ignoreCase);
      }

      ///<summary>
      /// Finds a collection of objects in the current list matching the search criteria.
      ///</summary>
      /// <param name="propertyName">Property of the object to search.</param>
      /// <param name="value">Value to find.</param>
      public virtual VList<T> FindAll(string propertyName, object value)
      {
         return FindAll(propertyName, value, true);
      }

      ///<summary>
      /// Finds a collection of objects in the current list matching the search criteria.
      ///</summary>
      /// <param name="propertyName">Property of the object to search.</param>
      /// <param name="value">Value to find.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      public virtual VList<T> FindAll(string propertyName, object value, bool ignoreCase)
      {
         PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
         PropertyDescriptor searchBy = props.Find(propertyName, true);

         VList<T> result = new VList<T>();

         int index = 0;

         while (index > -1)
         {
            index = this.FindCore(searchBy, value, index, ignoreCase);

            if (index > -1)
            {
				result.Add(this[index]);               

               	//Increment the index to start at the next item
               	index++;
            }
         }

         return result;
      }

		#region Find All By

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
        /// <param name="value">Value to find.</param>
        public virtual VList<T> FindAllBy(FindAllByType findAllByType, System.Enum column, object value)
        {
            return FindAllBy(findAllByType, column.ToString(), value, true);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
        /// <param name="value">Value to find.</param>
        /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
        public virtual VList<T> FindAllBy(FindAllByType findAllByType, System.Enum column, object value, bool ignoreCase)
        {
            return FindAllBy(findAllByType, column.ToString(), value, ignoreCase);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="propertyName">Property of the object to search.</param>
        /// <param name="value">Value to find.</param>
        public virtual VList<T> FindAllBy(FindAllByType findAllByType, string propertyName, object value)
        {
            return FindAllBy(findAllByType, propertyName, value, true);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="propertyName">Property of the object to search.</param>
        /// <param name="value">Value to find.</param>
        /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
        public virtual VList<T> FindAllBy(FindAllByType findAllByType, string propertyName, object value, bool ignoreCase)
        {
            PropertyDescriptorCollection props = base.PropertyCollection;
            PropertyDescriptor searchBy = props.Find(propertyName, true);

            VList<T> result = new VList<T>();

            int index = 0;

            while (index > -1)
            {
                index = this.FindAllBy(findAllByType, searchBy, value, index, ignoreCase);

                if (index > -1)
                {
                    result.Add(this[index]);

                    //Increment the index to start at the next item
                    index++;
                }
            }

            return result;
        }
		
        /// <summary>
        /// Searches for the index of the item that has the specified property descriptor with the specified value.
        /// </summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="prop">The <see cref="PropertyDescriptor"> to search for.</see></param>
        /// <param name="key">The value of <i>property</i> to match.</param>
        /// <param name="start">The index in the list at which to start the search.</param>
        /// <param name="ignoreCase">Indicator of whether to perform a case-sensitive or case insensitive search (string properties only).</param>
        /// <returns>The zero-based index of the item that matches the property descriptor and contains the specified value. </returns>
        protected virtual int FindAllBy(FindAllByType findAllByType, PropertyDescriptor prop, object key, int start, bool ignoreCase)
        {
            // Simple iteration:
            for (int i = start; i < Count; i++)
            {

                T item = this[i];
                object temp = prop.GetValue(item);
                if ((key == null) && (temp == null))
                {
                    return i;
                }
                else if (temp is string)
                {
                    switch(findAllByType)
                    {
                        case FindAllByType.StartsWith:
                            {
                               if (temp.ToString().StartsWith(key.ToString(), ignoreCase == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                                	return i;
                                break;
                            }
                        case FindAllByType.EndsWith:
                            {
                                if (temp.ToString().EndsWith(key.ToString(), ignoreCase == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                                	return i;
                                break;
                            }
                        case FindAllByType.Contains:
                            {
                                if (temp.ToString().Contains(key.ToString()))
                                	return i;
                                break; 
                            }
                    }
                }
                else if (temp != null && temp.Equals(key))
                {
                    return i;
                }
            }
            return -1; // Not found
        }
	    
	    ///<summary>
	    /// Used to by FindAllBy method to all for easy searching.
	    /// </summary>
	    [Serializable]
	    public enum FindAllByType
	    {
	        /// <summary>
	        /// Starts with Value in List
	        /// </summary>
	        StartsWith,
	        
	        /// <summary>
	        /// Ends with Value in List
	        /// </summary>
	        EndsWith,
	        
	        /// <summary>
	        /// Contains Value in List
	        /// </summary>
	        Contains
	    }
        #endregion Find All By
      #endregion Find

   }
}
