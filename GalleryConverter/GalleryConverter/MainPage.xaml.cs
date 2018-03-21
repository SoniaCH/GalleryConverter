using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GalleryConverter
{
    public partial class MainPage : ContentPage
    {
        #region the property
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        double dogImgSize = 80;
        public double DogImgSize
        {
            get { return dogImgSize; }
            set { SetProperty(ref dogImgSize, value); }
        }

        bool isCheckedDog = true;
        public bool IsCheckedDog
        {
            get { return isCheckedDog; }
            set { SetProperty(ref isCheckedDog, value); }
        }
        double catImgSize = 80;
        public double CatImgSize
        {
            get { return catImgSize; }
            set { SetProperty(ref catImgSize, value); }
        }

        bool isCheckedCat = true;
        public bool IsCheckedCat
        {
            get { return isCheckedCat; }
            set { SetProperty(ref isCheckedCat, value); }
        }

        bool isCheckedMonkey = true;
        public bool IsCheckedMonkey
        {
            get { return isCheckedMonkey; }
            set { SetProperty(ref isCheckedMonkey, value); }
        }

        bool isCheckedPanda = true;
        public bool IsCheckedPanda
        {
            get { return isCheckedPanda; }
            set { SetProperty(ref isCheckedPanda, value); }
        }

        bool isCheckedTiger = true;
        public bool IsCheckedTiger
        {
            get { return isCheckedTiger; }
            set { SetProperty(ref isCheckedTiger, value); }
        }
        #endregion

        public List<Animal> AnimalList;
        public string sourceImg;
        public string SourceImg
        {
            get { return sourceImg; }
            set
            {
                sourceImg = value;
                SetProperty(ref sourceImg, value);
            }
        }
        List<Animal> _item = new List<Animal>();



        #region methods tol load the list 

        public List<Animal> LoadTheListOfItems()
        {
            _item.Add(new Animal() { Id = "1", Img = "cat.jfif", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "1", Img = "cat.jfif", Categorie = "Cats" });
            _item.Add(new Animal() { Id = "3", Img = "dog.jfif", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "4", Img = "dog.jfif", Categorie = "Dogs" });
            _item.Add(new Animal() { Id = "5", Img = "panda.jfif", Categorie = "Pandas" });
            _item.Add(new Animal() { Id = "6", Img = "cat.jfif", Categorie = "Cats" });


            return _item;
        }

        #endregion

        public MainPage()
        {
            BindingContext = this;
            AnimalList = LoadTheListOfItems();
            InitializeComponent();
        }


        // just a test
        public ICommand TabTappedCommand
        {
            get
            {
                return new Command((e) =>
                {
                    if (IsCheckedDog == true)
                    {
                        //foreach (Animal animal in AnimalList)
                        //{
                        //    if (animal.Categorie == "Dogs")
                        //    {
                        //        SourceImg = animal.Img;
                        //    }
                        //}
                        SourceImg = "dog.jfif";

                    }
                    if (IsCheckedCat == true)
                    {
                        //foreach (Animal animal in AnimalList)
                        //{
                        //    if (animal.Categorie == "Cats")
                        //    {
                        //        SourceImg = animal.Img;
                        //    }
                        //}
                        SourceImg = "cat.jfif";
                    }

                    if (IsCheckedPanda == true)
                    {
                        //foreach (Animal animal in AnimalList)
                        //{
                        //    if (animal.Categorie == "Pandas")
                        //    {
                        //        SourceImg = animal.Img;
                        //    }
                        //}
                        SourceImg = "panda.jfif";
                    }

                    if (IsCheckedTiger == true)
                    {
                        foreach (Animal animal in AnimalList)
                        {
                            if (animal.Categorie == "Tigers")
                            {
                                SourceImg = animal.Img;
                            }
                        }
                    }

                });
            }

        }
        public ICommand OnCheck
        {
            get
            {
                return new Command((e) =>
                {
                    if (int.Parse(e.ToString()) == 1)
                    {
                        IsCheckedCat = true;
                        IsCheckedDog = false;
                        IsCheckedTiger = false;
                        IsCheckedPanda = false;
                    }
                    else if (int.Parse(e.ToString()) == 2)
                    {
                        IsCheckedCat = false;
                        IsCheckedDog = true;
                        IsCheckedTiger = false;
                        IsCheckedPanda = false;
                    }
                    else if (int.Parse(e.ToString()) == 3)
                    {
                        IsCheckedCat = false;
                        IsCheckedDog = false;
                        IsCheckedTiger = false;
                        IsCheckedPanda = true;
                    }
                    else if (int.Parse(e.ToString()) == 4)
                    {
                        IsCheckedCat = false;
                        IsCheckedDog = false;
                        IsCheckedTiger = true;
                        IsCheckedPanda = false;
                    }
                });
            }
        }
    }
}
