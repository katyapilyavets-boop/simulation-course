using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForestFireSimulation
{
    public partial class Form1 : Form
    {
        private ForestFireModel model;
        private System.Windows.Forms.Timer simulationTimer;
        private bool isRunning = false;
        private int cellSize = 15;

        public Form1()
        {
            InitializeComponent();
            InitializeModel();
            SetupTimer();
        }

        private void InitializeModel()
        {
            model = new ForestFireModel(60, 40);
            model.InitializeForest(0.6, false);
        }

        private void SetupTimer()
        {
            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 100;
            simulationTimer.Tick += SimulationTimer_Tick;
        }

        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            if (model.BurningTrees == 0 && isRunning)
            {
                StopSimulation();
                MessageBox.Show($"Пожар потушен!\nШагов: {model.StepCount}\nСгорело: {model.BurntTrees}",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            model.DoStep();
            pictureBox1.Invalidate();
            UpdateStats();
        }

        private void UpdateStats()
        {
            lblStep.Text = $"Шаг: {model.StepCount}";
            lblBurning.Text = $"Горят: {model.BurningTrees}";
            lblTrees.Text = $"Деревья: {model.TotalTrees}";
            lblBurnt.Text = $"Сгорело: {model.BurntTrees}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartSimulation();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                model.DoStep();
                pictureBox1.Invalidate();
                UpdateStats();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            StopSimulation();
            InitializeModel();
            ApplyParameters();
            pictureBox1.Invalidate();
            UpdateStats();
        }

        private void btnIgnite_Click(object sender, EventArgs e)
        {
            model.RandomIgnition(5);
            pictureBox1.Invalidate();
            UpdateStats();
        }

        private void StartSimulation()
        {
            isRunning = true;
            simulationTimer.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnStep.Enabled = false;
            btnReset.Enabled = false;
        }

        private void StopSimulation()
        {
            isRunning = false;
            simulationTimer.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnStep.Enabled = true;
            btnReset.Enabled = true;
        }

        private void ApplyParameters()
        {
            double temperature = trackTemp.Value / 10.0;
            double windStrength = trackWind.Value / 10.0;
            WindDirection windDir = (WindDirection)comboWindDirection.SelectedIndex;

            model.SetParameters(
                treeGrowth: 0.01,
                lightning: 0.001,
                temp: temperature,
                wind: windDir,
                windStr: windStrength
            );
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < model.Height; y++)
            {
                for (int x = 0; x < model.Width; x++)
                {
                    CellState state = model.GetCellState(x, y);
                    Color color = GetCellColor(state);

                    using (Brush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
                    }

                    using (Pen pen = new Pen(Color.LightGray))
                    {
                        g.DrawRectangle(pen, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }
        }

        private Color GetCellColor(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    return Color.Black;
                case CellState.Tree:
                    return Color.Green;
                case CellState.Burning:
                    return Color.Red;
                case CellState.Burnt:
                    return Color.DarkGray;
                case CellState.Barrier:
                    return Color.Blue;
                default:
                    return Color.Black;
            }
        }

        private void trackTemp_Scroll(object sender, EventArgs e)
        {
            lblTempValue.Text = (trackTemp.Value / 10.0).ToString("F1");
            ApplyParameters();
        }

        private void trackWind_Scroll(object sender, EventArgs e)
        {
            lblWindValue.Text = (trackWind.Value / 10.0).ToString("F1");
            ApplyParameters();
        }

        private void comboWindDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyParameters();
        }

        private void checkBoxBarriers_CheckedChanged(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                model.InitializeForest(0.6, checkBoxBarriers.Checked);
                pictureBox1.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboWindDirection.Items.AddRange(new string[] {
                "Нет ветра",
                "Север",
                "Северо-Восток",
                "Восток",
                "Юго-Восток",
                "Юг",
                "Юго-Запад",
                "Запад",
                "Северо-Запад"
            });
            comboWindDirection.SelectedIndex = 0;

            UpdateStats();
        }
    }

    // ==================== МОДЕЛЬ ====================

    public enum CellState
    {
        Empty = 0,//пустая земля
        Tree = 1,//дерево
        Burning = 2,//горит
        Burnt = 3,//сгорело
        Barrier = 4//барьер
    }

    public enum WindDirection
    {
        None = 0,
        North = 1,
        NorthEast = 2,
        East = 3,
        SouthEast = 4,
        South = 5,
        SouthWest = 6,
        West = 7,
        NorthWest = 8
    }

    public class Cell
    {
        public CellState State { get; set; }
        public int BurnTime { get; set; }
        public bool IsBarrier { get; set; }

        public Cell(CellState state = CellState.Empty)
        {
            State = state;
            BurnTime = 0;
            IsBarrier = state == CellState.Barrier;
        }
    }

    public class ForestFireModel
    {
        private Cell[,] grid;
        private Cell[,] nextGrid;
        private int width;
        private int height;

        private double treeGrowthProbability;
        private double lightningProbability;
        private double baseBurnProbability;
        private double temperature;
        private WindDirection windDirection;
        private double windStrength;
        private int burnDuration;

        private int stepCount;
        private int totalTrees;
        private int burningTrees;
        private int burntTrees;

        public ForestFireModel(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new Cell[width, height];
            nextGrid = new Cell[width, height];

            treeGrowthProbability = 0.01;
            lightningProbability = 0.001;
            baseBurnProbability = 0.7;
            temperature = 0.5;
            windDirection = WindDirection.None;
            windStrength = 0.0;
            burnDuration = 3;
            stepCount = 0;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new Cell();
                    nextGrid[x, y] = new Cell();
                }
            }
        }

        public void InitializeForest(double treeDensity = 0.6, bool addBarriers = false)
        {
            Random rand = new Random();
            totalTrees = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (addBarriers && rand.NextDouble() < 0.02)
                    {
                        int barrierLength = rand.Next(5, 15);
                        int dir = rand.Next(2);

                        if (dir == 0)
                        {
                            for (int i = 0; i < barrierLength && x + i < width; i++)
                            {
                                grid[x + i, y] = new Cell(CellState.Barrier);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < barrierLength && y + i < height; i++)
                            {
                                grid[x, y + i] = new Cell(CellState.Barrier);
                            }
                        }
                    }

                    if (grid[x, y].State != CellState.Barrier)
                    {
                        if (rand.NextDouble() < treeDensity)
                        {
                            grid[x, y].State = CellState.Tree;
                            totalTrees++;
                        }
                        else
                        {
                            grid[x, y].State = CellState.Empty;
                        }
                    }
                }
            }
        }

        public void Ignite(int x, int y)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                if (grid[x, y].State == CellState.Tree)
                {
                    grid[x, y].State = CellState.Burning;
                    grid[x, y].BurnTime = burnDuration;
                    burningTrees++;
                }
            }
        }

        public void RandomIgnition(int count = 5)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);
                Ignite(x, y);
            }
        }

        private double CalculateIgnitionProbability(int x, int y, int neighborX, int neighborY)
        {
            double probability = baseBurnProbability;
            probability *= (0.5 + temperature);

            if (windStrength > 0 && windDirection != WindDirection.None)
            {
                int dx = neighborX - x;
                int dy = neighborY - y;

                WindDirection directionToCell = GetDirection(dx, dy);

                if (directionToCell == windDirection || IsAdjacentDirection(directionToCell, windDirection))
                {
                    probability *= (1.0 + windStrength * 1.5);
                }
                else if (IsOppositeDirection(directionToCell, windDirection))
                {
                    probability *= (1.0 - windStrength * 0.5);
                }
            }

            return Math.Min(probability, 1.0);
        }

        private WindDirection GetDirection(int dx, int dy)
        {
            if (dx == 0 && dy == -1) return WindDirection.North;
            if (dx == 1 && dy == -1) return WindDirection.NorthEast;
            if (dx == 1 && dy == 0) return WindDirection.East;
            if (dx == 1 && dy == 1) return WindDirection.SouthEast;
            if (dx == 0 && dy == 1) return WindDirection.South;
            if (dx == -1 && dy == 1) return WindDirection.SouthWest;
            if (dx == -1 && dy == 0) return WindDirection.West;
            if (dx == -1 && dy == -1) return WindDirection.NorthWest;
            return WindDirection.None;
        }

        private bool IsAdjacentDirection(WindDirection dir1, WindDirection dir2)
        {
            int diff = Math.Abs((int)dir1 - (int)dir2);
            return diff == 1 || diff == 7;
        }

        private bool IsOppositeDirection(WindDirection dir1, WindDirection dir2)
        {
            return Math.Abs((int)dir1 - (int)dir2) == 4;
        }

        public void DoStep()
        {
            Random rand = new Random();
            int newBurningTrees = 0;
            int newBurntTrees = 0;
            int newTotalTrees = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell currentCell = grid[x, y];
                    Cell nextCell = nextGrid[x, y];

                    nextCell.State = currentCell.State;
                    nextCell.BurnTime = currentCell.BurnTime;
                    nextCell.IsBarrier = currentCell.IsBarrier;

                    if (currentCell.IsBarrier)
                    {
                        newTotalTrees++;
                        continue;
                    }

                    switch (currentCell.State)
                    {
                        case CellState.Burning:
                            nextCell.BurnTime--;
                            if (nextCell.BurnTime <= 0)
                            {
                                nextCell.State = CellState.Burnt;
                                newBurntTrees++;
                            }
                            else
                            {
                                newBurningTrees++;
                            }
                            break;

                        case CellState.Tree:
                            newTotalTrees++;
                            bool ignited = false;

                            for (int dx = -1; dx <= 1; dx++)
                            {
                                for (int dy = -1; dy <= 1; dy++)
                                {
                                    if (dx == 0 && dy == 0) continue;

                                    int nx = x + dx;
                                    int ny = y + dy;

                                    if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                                    {
                                        Cell neighbor = grid[nx, ny];
                                        if (neighbor.State == CellState.Burning)
                                        {
                                            double prob = CalculateIgnitionProbability(x, y, nx, ny);
                                            if (rand.NextDouble() < prob)
                                            {
                                                ignited = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (ignited) break;
                            }

                            if (!ignited && rand.NextDouble() < lightningProbability * (1 + temperature))
                            {
                                ignited = true;
                            }

                            if (ignited)
                            {
                                nextCell.State = CellState.Burning;
                                nextCell.BurnTime = burnDuration;
                                newBurningTrees++;
                                newTotalTrees--;
                            }
                            break;

                        case CellState.Empty:
                            if (rand.NextDouble() < treeGrowthProbability)
                            {
                                nextCell.State = CellState.Tree;
                                newTotalTrees++;
                            }
                            break;
                    }
                }
            }

            var temp = grid;
            grid = nextGrid;
            nextGrid = temp;

            stepCount++;
            burningTrees = newBurningTrees;
            burntTrees += newBurntTrees;
            totalTrees = newTotalTrees;
        }

        public void SetParameters(double treeGrowth, double lightning, double temp,
                                  WindDirection wind, double windStr)
        {
            this.treeGrowthProbability = treeGrowth;
            this.lightningProbability = lightning;
            this.temperature = Clamp(temp, 0, 1);
            this.windDirection = wind;
            this.windStrength = Clamp(windStr, 0, 1);
        }

        
        private double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        
        public int StepCount => stepCount;
        public int TotalTrees => totalTrees;
        public int BurningTrees => burningTrees;
        public int BurntTrees => burntTrees;
        public int Width => width;
        public int Height => height;

        public CellState GetCellState(int x, int y)
        {
            return grid[x, y].State;
        }
    }
}