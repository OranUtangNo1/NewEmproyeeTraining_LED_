using System.Collections.Generic;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        // LEDControlのリスト(画面の1行のイメージ)
        public List<LEDControl> LEDControls { get; set; }

        // コンボボックスの選択肢
        public IEnumerable<string> LEDOptions { get; set; } = new string[] { "消灯", "点灯" };

        public MainWindow()
        {
            // LEDControlの作成 1つの要素と画面の1行が対応するイメージ
            // サンプルなので、No10まで追加
            // 仕様書では100まで追加してほしいらしい
            // サンプルと同じように100こも書くのは面倒くさいので、関数とか使って100個作れると良い
            // 発光時間が空白　となっているので　仕様書通りの表示になるようにプログラム組みたい　
            LEDControls = new List<LEDControl>
            {
                new LEDControl { No = 1, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 2, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 3, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 4, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 5, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 6, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 7, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 8, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 9, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
                new LEDControl { No = 10, LED1 = "消灯", LED2 = "消灯", LED3 = "消灯", LED4 = "消灯", LED5 = "消灯", Time = string.Empty },
            };

            // 画面初期化
            InitializeComponent();

            // DataGrid にデータをバインド
            LEDDataGrid.DataContext = LEDControls;
        }

        #region Debug用
        /// <summary>
        /// デバッグ用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var no = this.CopmboDebugNo.SelectedIndex;
            var properties = typeof(LEDControl).GetProperties();
            var message= string.Empty;
            foreach (var property in properties)
            {
                message += $"{property.Name}: {property.GetValue(this.LEDControls[no])} \n";
            }
            MessageBox.Show(message);
        }
        #endregion Debug用
    }

    public class LEDControl
    {
        /// <summary>
        /// No
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// LEDグループ
        /// </summary>
        //赤
        public string LED1 { get; set; }
        //黄色
        public string LED2 { get; set; }
        //緑
        public string LED3 { get; set; }
        //青
        public string LED4 { get; set; }
        //白
        public string LED5 { get; set; }
    }
}
