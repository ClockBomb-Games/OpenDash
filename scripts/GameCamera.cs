/*
	Open Dash - An open-source game inspired by Geometry Dash.
	Copyright (C) 2024 Edgar Lima (RobotoSkunk)

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Godot;


namespace ClockBombGames
{
	public partial class GameCamera : Camera2D
	{
		[Export] private Node2D target;
		[Export] private StaticBody2D floor;


		public override void _Process(double delta)
		{
			if (target != null) {
				GlobalPosition = new Vector2(target.GlobalPosition.X, GlobalPosition.Y);
			}
		}

		public override void _PhysicsProcess(double delta)
		{
			floor.GlobalPosition = new Vector2(GlobalPosition.X, 60f);
		}
	}
}
