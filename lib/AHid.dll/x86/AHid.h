/*****************************************************************************************************

Module:		AHid.h (v1.91)

Author:		(c) 2012-2013 basic IO UG (haftungsbeschraenkt). All rights reserved.

Purpose:	Interface to the AHid Functions Library

*****************************************************************************************************/
#pragma once

#include <windows.h>

#ifndef AHIDLIBAPI
#define AHIDLIBAPI extern "C" __declspec(dllimport)
#endif //AHIDLIBAPI

//Windows messages.
#define AHID_DEVICECHANGE				WM_DEVICECHANGE
#define AHID_DATARECEIVED				(WM_USER+101) 

//Report types.
#define AHID_REPTYPE_INT_IN				0
#define AHID_REPTYPE_INT_OUT			1
#define AHID_REPTYPE_FEATURE			2

//Status values.
#define AHID_OK							0
#define AHID_ATTACHED					1
#define AHID_REMOVED					2
#define AHID_NOT_LISTED					3
#define AHID_IO_ERROR					4
#define AHID_NOT_INITIALIZED			5
#define AHID_LICENSE_ERROR				6	//A Free License limitation occurs.
#define AHID_OTHER_ERROR				7


/*** Functions **************************************************************************************/

/*** AHid_Init ***************************************************************************************

Purpose:		AHID.DLL initialisation.

Parameters:		hwnd				- A window handle to your Windows Message Queue.
				parm1				- Paramter #1 (required for licensing)

Return values:	AHID_OTHER_ERROR	- Initialisation failed.
				AHID_OK				- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Init( int hwnd, byte* parm1 );


/*** AHid_Register **********************************************************************************

Purpose:		Register a pipe for data transfers.

Parameters:		*pipe					- A reference to your data pipe. This value is used as a 
										  handle throughout the function interface.
				vid						- Your device's Vendor ID
				pid						- Your device's Product ID
				mi						- Composite ID (use -1 in normal case)
				rep_id					- Report ID (use 0 in normal case)
				rep_size				- Report size (compare to your device)
				rep_type				- Report type (compare to your device)

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_OTHER_ERROR		- Registration failed.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Register( int* pipe, unsigned int vid, unsigned int pid, int mi, 
										byte rep_id, byte rep_size, byte rep_type );


/*** AHid_Deregister ********************************************************************************

Purpose:		Remove pipe from registration.

Parameters:		pipe					- The data pipe handle to remove.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Deregister( int pipe );


/*** AHid_Write *************************************************************************************

Purpose:		Write data to USB device.

Parameters:		pipe					- The data pipe handle.
				buffer					- Transfer buffer.
				to_write				- Number of bytes to write.
				*written				- Reference to the number of bytes written.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_IO_ERROR			- Write failed.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Write( int pipe, byte* buffer, unsigned int to_write, unsigned int* written );


/*** AHid_Read **************************************************************************************

Purpose:		Read data from USB device.

Parameters:		pipe					- The data pipe.
				buffer					- Transfer buffer.
				to_read					- Number of bytes to read.
				*read					- Reference to the number of bytes read.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_IO_ERROR			- Read failed.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Read( int pipe, byte* buffer, unsigned int to_read, unsigned int* read );


/*** AHid_Request ***********************************************************************************

Purpose:		Request a Feature Report from USB device.

Parameters:		pipe					- The data pipe handle.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_OTHER_ERROR		- Unable to transfer Feature Reports.
				AHID_IO_ERROR			- Feature Report failed.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Request( int pipe );


/*** AHid_Attached **********************************************************************************

Purpose:		Monitor device status on USB.

Parameters:		pipe					- The data pipe handle.
				wparam					- WPARAM value.
				lparam					- LPARAM value.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_ATTACHED			- Device attached.
				AHID_REMOVED			- Device removed.
				AHID_OTHER_ERROR		- Device not involved in bus change.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Attached( int pipe, WPARAM wparm, LPARAM lparm );


/*** AHid_Find **************************************************************************************

Purpose:		Find device on USB.

Parameters:		pipe					- The data pipe handle.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_OTHER_ERROR		- Device not found on USB.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Find( int pipe );


/*** AHid_Info **************************************************************************************

Purpose:		Show an info box.

Parameters:		-

Return values:	AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Info( void );

/*** AHid_Setup *************************************************************************************

Purpose:		Display registration information.

Parameters:		pipe					- The data pipe handle.

Return values:	AHID_NOT_INITIALIZED	- AHID.DLL not initialised yet.
				AHID_NOT_LISTED			- Data pipe not registered.
				AHID_OK					- No error.
				
****************************************************************************************************/
AHIDLIBAPI int AHid_Setup( int pipe );


