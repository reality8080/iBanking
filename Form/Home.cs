using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBanking
{
    public partial class Home : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        //private ILogger<Home> _logger = new ILogger<Home>();
        public Home(IServiceProvider _serviceProvider)
        {
            InitializeComponent();
            this._serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            //this._logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

    }
}
