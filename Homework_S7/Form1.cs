using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_S7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                        
            retrieveCards();
        }

        async void retrieveCards() {
            SetAuthorization();
            ITrelloFactory factory = new TrelloFactory();
            string id = "4d5ea62fd76aa1136000000c";
            try {
                var board = new Board(id);
                await board.Refresh();
                var lists = board.Lists;
                var cards = board.Cards;
                await cards.Refresh();

                foreach (Manatee.Trello.Card card in cards)
                {
                    listView1.Items.Add(card.Name);

                }
                /*
                foreach (Manatee.Trello.List list in lists) {
                    listView1.Items.Add(list.Name);
                    foreach (Manatee.Trello.Card card in list.Cards)
                    listView1.Items.Add(card.Name);

                }
                */
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        void SetAuthorization() {
           TrelloAuthorization.Default.AppKey = "see mdasTools_homework_S7.docx > Exercise 2";
           TrelloAuthorization.Default.UserToken = "see mdasTools_homework_S7.docx > Exercise 2";
        }
    }
}
