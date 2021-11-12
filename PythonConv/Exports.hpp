#pragma once


#include <string>

#include <stdio.h>
#include <stdlib.h>

#include <Python.h>


using namespace std;
typedef void(*TMsgBox)(WCHAR*);

void Execute(string Path) {
    FILE* fp = NULL; 
    fopen_s(&fp, Path.c_str(), "r");

    PyRun_SimpleFile(fp, Path.c_str());

    fclose(fp);
}

#define DLLAPI extern "C" __declspec(dllexport)
DLLAPI void ExecuteStr(CHAR* C) {
    PyRun_SimpleString(C);
}
DLLAPI TMsgBox _MessageBox = NULL;
DLLAPI void MessageBoxC(WCHAR* Str) {
    _MessageBox(Str);
}
DLLAPI void MessageBoxS(TMsgBox _MessageBox) { 
    ::_MessageBox = _MessageBox;
    ExecuteStr((char*)"MessageBoxC(\"ff\")");

    
}

DLLAPI void Init()
{
    Py_Initialize();
    Execute("Modules.py");
    Execute("Script.py");

    PyRun_SimpleString("Start()");

}

DLLAPI void Flna() 
{
    Py_Finalize();
}

