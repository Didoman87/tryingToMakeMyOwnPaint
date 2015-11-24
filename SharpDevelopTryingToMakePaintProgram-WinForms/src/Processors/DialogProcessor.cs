using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		private Shape  selection;
		public Shape Selection {
			get { return selection; }
			set { selection = value; }
   		}

        private List<Shape> allSelectionFigures = new List<Shape>();
        public List<Shape> AllSelectionFigures
        {
            get { return allSelectionFigures; }
            set { allSelectionFigures = value; }
        }
        
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;

			ShapeList.Add(rect);
		}

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape oval = new EllipseShape(new Rectangle(x, y, 100, 200));
            oval.FillColor = Color.LightBlue;

            ShapeList.Add(oval);
        }
		
		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					ShapeList[i].FillColor = Color.Red;
                //    AllSelectionFigures.Add(ShapeList[i]);	
					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
           //if (ShapeList.Count > 1)
           //{
           //    do {
           //
           //    } while (ShapeList.Count = 0)
           //}

           //for (int i = ShapeList.Count - 1; i >= 0; i--)
           //{
           //    if (ShapeList[i].Contains(p))
           //    {
           //        ShapeList[i].FillColor = Color.Red;
            
               if (selection != null)
               {
                   for (int i = allSelectionFigures.Count - 1; i >= 0; i--)
                   {
                       selection = allSelectionFigures[i];
                       //Nqkade tuka e problema iskam da povtarq dolnoto presmqtane za vseki selectiran element
                       //za tova e cikala i toi raboti ,no qvno ima problem v PointF moje bi ?
                       selection.Location = new PointF(selection.Location.X + p.X - LastLocation.X,
                           selection.Location.Y + p.Y - LastLocation.Y);
                       
                       //Test za da vidim dali vlizameme v Cikala 
                      //if (i == 1)
                      //{
                      //
                      //}
                    
                   }
                   lastLocation = p;
               }
           // }

			
		}
	}
}
