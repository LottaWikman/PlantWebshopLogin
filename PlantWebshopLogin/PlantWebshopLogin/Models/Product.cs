﻿using PlantWebshopLogin.Data;

namespace PlantWebshopLogin.Models;

public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public double? OldPrice { get; set; }
	public string? ImageUrl { get; set; }
	public int Quantity { get; set; }

}