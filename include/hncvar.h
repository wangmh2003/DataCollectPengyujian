/*
* Copyright (c) 2013, �人�������عɷ����޹�˾
* All rights reserved.
* 
* �ļ����ƣ�hncvar.h
* �ļ���ʶ���������ù����ƻ���
* ժ    Ҫ�������ӿ�
* ����ƽ̨��Linux/Windows
* 
* ��    ����1.00
* ��    �ߣ�HNC-8 Team
* ��    �ڣ�2013��6��20��
* ˵    ��������ֵ˵����
*           0���ɹ���
*           1���첽��ȡ������δ��ȡ�����ݣ�
*           -1��������������Ͳ�ƥ�䣻
*           -2����ų������ƣ�
*           -3��ͨ���ų������ƣ�
*           -4������������ų������ƣ�
*           -5��ͨ�����������ų������ƣ�
*           -6��ϵͳ���������ų������ƣ�
*           -7������λ�ų������ƣ�
*           -8������ֵָ��Ϊ�գ�
*/

#ifndef __HNC_VAR_H__
#define __HNC_VAR_H__

#include "hncdatatype.h"

// ��������
enum HncVarType
{
	VAR_TYPE_AXIS = 0,	// ����� {Get(Bit32), Set(Bit32)}
	VAR_TYPE_CHANNEL,	// ͨ������ {Get(Bit32), Set(Bit32)}
	VAR_TYPE_SYSTEM,	// ϵͳ���� {Get(Bit32), Set(Bit32)}
	VAR_TYPE_SYSTEM_F,	// �������͵�ϵͳ���� {Get(fBit64), Set(fBit64)}
	VAR_TYPE_TOTAL
};

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_VarGetValue(Bit32 type, Bit32 no, Bit32 index, void *value, Bit16 clientNo)
//
//    ���ܣ�
//            ��ȡ������ֵ
//
//    ������
//            type		���������ͣ�enum HncVarType
//            no		����Ż���ͨ���ţ�
//            index		�������ţ�
//            value		������ֵ��
//            clientNo	���������Ӻţ�
//
//    ������
//            no�����������ţ�ͨ��������ͨ���ţ�ϵͳ������0��
//
//    ���أ�
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_VarGetValue(Bit32 type, Bit32 no, Bit32 index, void *value, Bit16 clientNo = 0);

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_VarSetValue(Bit32 type, Bit32 no, Bit32 index, void *value, Bit16 clientNo)
//
//    ���ܣ�
//            ���ñ�����ֵ
//
//    ������
//            type		���������ͣ�enum HncVarType
//            no		����Ż���ͨ���ţ�
//            index		�������ţ�
//            value		������ֵ��
//            clientNo	���������Ӻţ�
//
//    ������
//            no�����������ţ�ͨ��������ͨ���ţ�ϵͳ������0��
//
//    ���أ�
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_VarSetValue(Bit32 type, Bit32 no, Bit32 index, void *value, Bit16 clientNo = 0);

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_VarSetBit(Bit32 type, Bit32 no, Bit32 index, Bit32 bit, Bit16 clientNo)
//
//    ���ܣ�
//            ���ñ������ݵ�һλ
//
//    ������
//            type		���������ͣ�enum HncVarType
//            no		����Ż���ͨ���ţ�
//            index		�������ţ�
//            bit		������λ�ţ�
//            clientNo	���������Ӻţ�
//
//    ������
//            no�����������ţ�ͨ��������ͨ���ţ�ϵͳ������0��
//
//    ���أ�
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_VarSetBit(Bit32 type, Bit32 no, Bit32 index, Bit32 bit, Bit16 clientNo = 0);

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_VarClrBit(Bit32 type, Bit32 no, Bit32 index, Bit32 bit, Bit16 clientNo)
//
//    ���ܣ�
//            ����������ݵ�һλ
//
//    ������
//            type		���������ͣ�enum HncVarType
//            no		����Ż���ͨ���ţ�
//            index		�������ţ�
//            bit		������λ�ţ�
//            clientNo	���������Ӻţ�
//
//    ������
//            no�����������ţ�ͨ��������ͨ���ţ�ϵͳ������0��
//
//    ���أ� 
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_VarClrBit(Bit32 type, Bit32 no, Bit32 index, Bit32 bit, Bit16 clientNo = 0);

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_MacroVarGetValue(Bit32 no, SDataUnion *var, Bit16 clientNo)
//
//    ���ܣ�
//            ��ȡ�������ֵ
//
//    ������
//            no		��������ţ�
//            var		������ֵ��
//            clientNo	���������Ӻţ�
//
//    ������
//            �������˵����
//            [0, 2999]��ͨ��������
//            [40000, 59999]��ϵͳ���������У�[50000, 54999]���û��Զ��������
//            [60000, 69999]���������
//            [70000, 99999]�����߱�����
//            ��ϸ˵���μ�������8������ϵͳ�û�˵���顷���û������
//
//    ���أ�
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_MacroVarGetValue(Bit32 no, SDataUnion *var, Bit16 clientNo = 0);

///////////////////////////////////////////////////////////////////////////////
//
//    Bit32 HNC_MacroVarSetValue(Bit32 no, SDataUnion *var, Bit16 clientNo)
//
//    ���ܣ�
//            ���ú������ֵ
//
//    ������
//            no		��������ţ�
//            var		������ֵ��
//            clientNo	���������Ӻţ�
//
//    ������
//            �����û��Զ������[50000, 54999]��
//
//    ���أ�
//            0���ɹ�����0��ʧ�ܣ��μ�����ֵ˵����
//
//////////////////////////////////////////////////////////////////////////
HNCAPI Bit32 HNC_MacroVarSetValue(Bit32 no, SDataUnion *var, Bit16 clientNo = 0);

#endif // __HNC_VAR_H__