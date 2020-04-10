
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;



        private FruitFilling fruitFilling;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit {
            get { return fruitFilling; }
            set
            {
                fruitFilling = value;
                NotifyIfPropertyChanges("Fruit");
            }
        
        }


        private bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get { return withIceCream; }
            set
            {
                withIceCream = value;
                NotifyIfPropertyChanges("WithIceCream");
                NotifyIfPropertyChanges("SpecialInstructions");
                NotifyIfPropertyChanges("Price");
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream)
                {

                    return 5.32;
                }
                else {
                    
                    return 4.25;
                } 
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {

                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        /// <summary>
        /// Overrides Originat ToString Method in order to specify which Fruit Filling will be in the Cobbler.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Fruit.ToString()} Cobbler";
        }

        /// <summary>
        /// Helper function that Notifies if the given property has changed
        /// </summary>
        /// <param name="property">property name</param>
        protected void NotifyIfPropertyChanges(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
