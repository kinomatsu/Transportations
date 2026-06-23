using Transportations.BLL;

namespace Transportations
{
    /// <summary>
    /// Диалог добавления / редактирования одной записи.
    /// Поля строятся динамически по столбцам таблицы.
    /// </summary>
    public partial class EditRecordForm
    {
        private readonly DataService _data;

        private string?                     _tableName;
        private Dictionary<string, object>? _original;
        private bool                        _isNew;

        private readonly Dictionary<string, TextBox> _fields = new();

        public EditRecordForm(DataService data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            InitializeComponent();
        }

        /// <summary>Инициализирует перед показом. null = новая запись.</summary>
        public void Init(string tableName, Dictionary<string, object>? existing)
        {
            _tableName = tableName;
            _original  = existing;
            _isNew     = existing == null;
            Text       = _isNew ? $"Добавить — {tableName}" : $"Изменить — {tableName}";
            BuildFields();
        }

        private void BuildFields()
        {
            _fields.Clear();
            panelFields.Controls.Clear();

            var pkCol = DataService.GetPrimaryKey(_tableName!);
            var cols  = _isNew ? SchemaFor(_tableName!) : _original!.Keys.ToList();

            int y = 10;
            foreach (var col in cols)
            {
                if (_isNew && col == pkCol) continue;   // PK не вводим при добавлении

                var lbl = new Label
                {
                    Text     = col,
                    Font     = new Font("Segoe UI", 9F),
                    Location = new Point(10, y + 2),
                    Size     = new Size(160, 20),
                };
                var txt = new TextBox
                {
                    Font     = new Font("Segoe UI", 10F),
                    Location = new Point(175, y),
                    Size     = new Size(260, 26),
                    Text     = _isNew ? "" : _original![col]?.ToString() ?? "",
                };
                panelFields.Controls.Add(lbl);
                panelFields.Controls.Add(txt);
                _fields[col] = txt;
                y += 40;
            }
            panelFields.AutoScrollMinSize = new Size(0, y + 20);
        }

        private void btnSave_Click(object? sender, EventArgs e)   => TrySave();
        private void btnCancel_Click(object? sender, EventArgs e) => Close();

        private void TrySave()
        {
            var values = CollectValues();
            if (values == null) return;

            try
            {
                if (_isNew)
                {
                    _data.Insert(_tableName!, values);
                }
                else
                {
                    var pk      = DataService.GetPrimaryKey(_tableName!);
                    var pkValue = _original![pk];
                    values.Remove(pk);
                    _data.Update(_tableName!, pkValue, values);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Dictionary<string, object>? CollectValues()
        {
            var result = new Dictionary<string, object>();
            foreach (var kv in _fields)
            {
                if (string.IsNullOrWhiteSpace(kv.Value.Text))
                {
                    MessageBox.Show($"Поле «{kv.Key}» не может быть пустым.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kv.Value.Focus();
                    return null;
                }
                result[kv.Key] = kv.Value.Text.Trim();
            }
            return result;
        }

        // Столбцы для новых записей (без PK — он автоинкремент)
        private static List<string> SchemaFor(string t) => t switch
        {
            "Водители"  => ["DriverID",   "ФИО",          "НомерПрав",  "Телефон",   "Статус"],
            "Грузы"     => ["CargoID",    "Наименование", "Вес(КГ)",    "Тип"],
            "Клиенты"   => ["ClientID",   "Название",     "КонтактноеЛицо", "Телефон", "Адрес"],
            "Рейсы"     => ["TripID",     "НомерРейса",   "ДатаОтправки",
                            "КлиентID",   "ВодительID",   "ТранспортID",
                            "ПунктНазначения", "Статус",  "Стоимость"],
            "Транспорт" => ["VehicleID",  "ГосНомер",     "Марка",      "Грузоподъемность(КГ)", "Статус"],
            _           => [],
        };
    }
}
