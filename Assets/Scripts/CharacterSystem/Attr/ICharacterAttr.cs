using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;

    protected int mCurrentHP;
    protected string mIconSprite;

    protected int mLv;
    protected float mCritRate;//������0-1
    //���ӵ����Ѫ�� �������˺�ֵ �������ӵ��˺�

    protected IAttrStrategy mStrategy;
}
