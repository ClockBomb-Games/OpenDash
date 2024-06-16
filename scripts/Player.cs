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
	public partial class Player : CharacterBody2D
	{
		[ExportGroup("Properties")]
		[Export] private float Speed;
		[Export] private float JumpVelocity;
		[Export] private float rotationSpeed;

		[ExportGroup("Components")]
		[Export] private Sprite2D sprite;

		private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		private float rotationBuffer;

		private Vector2 startPosition;


		public override void _Ready()
		{
			startPosition = GlobalPosition;
		}

		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Velocity;
			velocity.X = Speed;


			if (!IsOnFloor()) {
				velocity.Y += gravity * (float)delta;
			}

			if (Input.IsActionPressed("jump") && IsOnFloor()) {
				velocity.Y = -JumpVelocity;
			}
			if (Input.IsKeyPressed(Key.R)) {
				GlobalPosition = startPosition;
			}


			Velocity = velocity;

			MoveAndSlide();


			if (!IsOnFloor()) {
				sprite.RotationDegrees += rotationSpeed * (float)delta;

				rotationBuffer = Mathf.Round(sprite.RotationDegrees / 90f) * 90f;

			} else {
				sprite.Rotation = Mathf.LerpAngle(sprite.Rotation, Mathf.DegToRad(rotationBuffer), 0.3f);
			}
		}
	}
}
