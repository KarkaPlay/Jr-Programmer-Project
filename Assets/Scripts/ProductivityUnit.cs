using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile;
    public float ProductivityMultiplier = 2;
    
    protected override void BuildingInRange()
    {
        if (!m_CurrentPile)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
