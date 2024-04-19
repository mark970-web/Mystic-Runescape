using Godot;
using System;
using MysticRunescape;

public class HealingSpell : Spell
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public string ResourcePath = "res://miscs/HealingSpell.tscn";
    public bool PlayerInArea;
    
    
    public HealingSpell()
    {
        InterfaceTexturePath = "res://miscs/HealingSpell/1.png";
        InterfaceTexture = ResourceLoader.Load(InterfaceTexturePath) as Texture;
    }
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("idle");
    }

    public override void SetUp(bool facedirection)
    {
        GetNode<Sprite>("Sprite").FlipH = facedirection;
        faceDirection = facedirection;
    }
    
    public override void CastSpell()
    {
        
    }
    
    public override void LoadResourcePath()
    {
      
    }

    public override void _PhysicsProcess(float delta)
    {
        if (PlayerInArea)
        {
            if (GameManager.Player.Health < GameManager.Player.MaxHealth)
            {
                GameManager.Player.Health += delta * DamageAmount;
            }
        }
        LifeSpan -= delta;
        if (LifeSpan < 0)
        {
            QueueFree();
        }
    }

    public void _on_Area2D_body_entered(object body)
    {
        if (body is Adventurer)
        {
            PlayerInArea = true;
        }
    }

    public void _on_Area2D_body_exited(object body)
    {
        if (body is Adventurer)
        {
            PlayerInArea = false;
        }
    }


}