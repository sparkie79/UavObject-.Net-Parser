UavObject-.Net-Parser
=====================

A small .NET tool helpful to analyze Uavobj log data files generated with Openpilot gcs.

Uavobjects are generated by a T4 text template from uavobjects definition xml

- UavobjectParser: Library to help T4 code generator to parse xml uavobjects definition

- Uavtalk: Code to parse and manage data objects. Data could be retrieved from file or usb/comm connection

- ObjViewer: A basic example project to select and graph GCS log data. 

  ![](https://raw.github.com/sparkie79/UavObject-.Net-Parser/master/Images/Sample.png)
  
  Magnetometer data can be visualized in a 3d scatter plot
  ![](https://raw.github.com/sparkie79/UavObject-.Net-Parser/master/Images/scatter.png)

- TestConsole: A simple project to manipulate log data and export content to Matlab .mat file
