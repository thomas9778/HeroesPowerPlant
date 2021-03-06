﻿using SharpDX;

namespace HeroesPowerPlant.LayoutEditor
{
    public class Object0987_RedGreenPlant : SetObjectHeroes
    {
        public override void CreateTransformMatrix()
        {
            transformMatrix = Matrix.Scaling(Scale) * DefaultTransformMatrix();
            CreateBoundingBox();
        }

        public float Scale
        {
            get => ReadFloat(4);
            set => Write(4, value);
        }
        public int ObjectType
        {
            get => ReadInt(8);
            set => Write(8, value);
        }
    }
}