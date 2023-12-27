using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DM02Bridge : MonoBehaviour
{
    private void Start()
    {
        //IRenderEngine re = new OpenGL();
        //IRenderEngine re = new DriectX();

        //IRenderEngine re = new SuperRender();
        //Sphere sphere = new Sphere(re);
        //sphere.Draw();
        //Cube cube = new Cube(re);
        //cube.Draw();
        //Capsule capsule = new Capsule(re);
        //capsule.Draw();

        ICharacter character = new SoldierCaptain();
        character.weapon = new WeaponLaser();
        character.Attack(Vector3.one);
    }
}

public class IShape
{
    public string name;
    public IRenderEngine renderEngine;
    public IShape(IRenderEngine renderEngine)
    {
        this.renderEngine = renderEngine;
    }

    public void Draw()
    {
        renderEngine.Render(name);
    }
}

public abstract class IRenderEngine
{
    public abstract void Render(string name);
}

public class Sphere : IShape
{
    public Sphere(IRenderEngine re) : base(re)
    {
        name = "Sphere";
    }
}

public class Cube : IShape
{
    public Cube(IRenderEngine re) : base(re)
    {
        name = "Cube";
    }
}

public class Capsule : IShape
{
    public Capsule(IRenderEngine re) : base(re)
    {
        name = "Capsule";
    }
}

public class OpenGL : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("OpenGL绘制完成了：" + name);
    }
}

public class DriectX : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DriectX绘制完成了：" + name);
    }
}

public class SuperRender : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("SuperRender绘制完成了：" + name);
    }
}
