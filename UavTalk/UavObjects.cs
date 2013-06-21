
using UavTalk;

public static class UAVObjectsInitialize
{
	public static void register(UAVObjectManager objMngr) {
		
		objMngr.registerObject( new Accels() );
		
		objMngr.registerObject( new AccessoryDesired() );
		
		objMngr.registerObject( new ActuatorCommand() );
		
		objMngr.registerObject( new ActuatorDesired() );
		
		objMngr.registerObject( new ActuatorSettings() );
		
		objMngr.registerObject( new ADCRouting() );
		
		objMngr.registerObject( new AirspeedActual() );
		
		objMngr.registerObject( new AirspeedSettings() );
		
		objMngr.registerObject( new AltHoldSmoothed() );
		
		objMngr.registerObject( new AltitudeHoldDesired() );
		
		objMngr.registerObject( new AltitudeHoldSettings() );
		
		objMngr.registerObject( new AttitudeActual() );
		
		objMngr.registerObject( new AttitudeSettings() );
		
		objMngr.registerObject( new AttitudeSimulated() );
		
		objMngr.registerObject( new BaroAirspeed() );
		
		objMngr.registerObject( new BaroAltitude() );
		
		objMngr.registerObject( new CameraDesired() );
		
		objMngr.registerObject( new CameraStabSettings() );
		
		objMngr.registerObject( new FaultSettings() );
		
		objMngr.registerObject( new FirmwareIAPObj() );
		
		objMngr.registerObject( new FixedWingAirspeeds() );
		
		objMngr.registerObject( new FixedWingPathFollowerSettings() );
		
		objMngr.registerObject( new FixedWingPathFollowerSettingsCC() );
		
		objMngr.registerObject( new FixedWingPathFollowerStatus() );
		
		objMngr.registerObject( new FlightBatterySettings() );
		
		objMngr.registerObject( new FlightBatteryState() );
		
		objMngr.registerObject( new FlightPlanControl() );
		
		objMngr.registerObject( new FlightPlanSettings() );
		
		objMngr.registerObject( new FlightPlanStatus() );
		
		objMngr.registerObject( new FlightStatus() );
		
		objMngr.registerObject( new FlightTelemetryStats() );
		
		objMngr.registerObject( new GCSReceiver() );
		
		objMngr.registerObject( new GCSTelemetryStats() );
		
		objMngr.registerObject( new GPSPosition() );
		
		objMngr.registerObject( new GPSSatellites() );
		
		objMngr.registerObject( new GPSTime() );
		
		objMngr.registerObject( new GPSVelocity() );
		
		objMngr.registerObject( new GroundPathFollowerSettings() );
		
		objMngr.registerObject( new GroundTruth() );
		
		objMngr.registerObject( new Gyros() );
		
		objMngr.registerObject( new GyrosBias() );
		
		objMngr.registerObject( new HomeLocation() );
		
		objMngr.registerObject( new HwCopterControl() );
		
		objMngr.registerObject( new HwDiscoveryF4() );
		
		objMngr.registerObject( new HwFlyingF3() );
		
		objMngr.registerObject( new HwFlyingF4() );
		
		objMngr.registerObject( new HwFreedom() );
		
		objMngr.registerObject( new HwQuanton() );
		
		objMngr.registerObject( new HwRevolution() );
		
		objMngr.registerObject( new HwRevoMini() );
		
		objMngr.registerObject( new HwSparky() );
		
		objMngr.registerObject( new I2CStats() );
		
		objMngr.registerObject( new I2CVM() );
		
		objMngr.registerObject( new I2CVMUserProgram() );
		
		objMngr.registerObject( new INSSettings() );
		
		objMngr.registerObject( new INSState() );
		
		objMngr.registerObject( new MagBias() );
		
		objMngr.registerObject( new Magnetometer() );
		
		objMngr.registerObject( new ManualControlCommand() );
		
		objMngr.registerObject( new ManualControlSettings() );
		
		objMngr.registerObject( new MixerSettings() );
		
		objMngr.registerObject( new MixerStatus() );
		
		objMngr.registerObject( new ModuleSettings() );
		
		objMngr.registerObject( new NedAccel() );
		
		objMngr.registerObject( new NEDPosition() );
		
		objMngr.registerObject( new ObjectPersistence() );
		
		objMngr.registerObject( new OPLinkSettings() );
		
		objMngr.registerObject( new OPLinkStatus() );
		
		objMngr.registerObject( new OveroSyncSettings() );
		
		objMngr.registerObject( new OveroSyncStats() );
		
		objMngr.registerObject( new PathDesired() );
		
		objMngr.registerObject( new PathPlannerSettings() );
		
		objMngr.registerObject( new PathStatus() );
		
		objMngr.registerObject( new PoiLocation() );
		
		objMngr.registerObject( new PositionActual() );
		
		objMngr.registerObject( new RateDesired() );
		
		objMngr.registerObject( new ReceiverActivity() );
		
		objMngr.registerObject( new RelayTuning() );
		
		objMngr.registerObject( new RelayTuningSettings() );
		
		objMngr.registerObject( new SensorSettings() );
		
		objMngr.registerObject( new SonarAltitude() );
		
		objMngr.registerObject( new StabilizationDesired() );
		
		objMngr.registerObject( new StabilizationSettings() );
		
		objMngr.registerObject( new StateEstimation() );
		
		objMngr.registerObject( new SystemAlarms() );
		
		objMngr.registerObject( new SystemSettings() );
		
		objMngr.registerObject( new SystemStats() );
		
		objMngr.registerObject( new TabletInfo() );
		
		objMngr.registerObject( new TaskInfo() );
		
		objMngr.registerObject( new TxPIDSettings() );
		
		objMngr.registerObject( new VelocityActual() );
		
		objMngr.registerObject( new VelocityDesired() );
		
		objMngr.registerObject( new VibrationAnalysisOutput() );
		
		objMngr.registerObject( new VibrationAnalysisSettings() );
		
		objMngr.registerObject( new VtolPathFollowerSettings() );
		
		objMngr.registerObject( new WatchdogStatus() );
		
		objMngr.registerObject( new Waypoint() );
		
		objMngr.registerObject( new WaypointActive() );
	}
}
// Generated helper templates
// Generated items
// UavTalk\UavTalk\WaypointActive.cs
// UavTalk\UavTalk\Waypoint.cs
// UavTalk\UavTalk\WatchdogStatus.cs
// UavTalk\UavTalk\VtolPathFollowerSettings.cs
// UavTalk\UavTalk\VibrationAnalysisSettings.cs
// UavTalk\UavTalk\VibrationAnalysisOutput.cs
// UavTalk\UavTalk\VelocityDesired.cs
// UavTalk\UavTalk\VelocityActual.cs
// UavTalk\UavTalk\TxPIDSettings.cs
// UavTalk\UavTalk\TaskInfo.cs
// UavTalk\UavTalk\TabletInfo.cs
// UavTalk\UavTalk\SystemStats.cs
// UavTalk\UavTalk\SystemSettings.cs
// UavTalk\UavTalk\SystemAlarms.cs
// UavTalk\UavTalk\StateEstimation.cs
// UavTalk\UavTalk\StabilizationSettings.cs
// UavTalk\UavTalk\StabilizationDesired.cs
// UavTalk\UavTalk\SonarAltitude.cs
// UavTalk\UavTalk\SensorSettings.cs
// UavTalk\UavTalk\RelayTuningSettings.cs
// UavTalk\UavTalk\RelayTuning.cs
// UavTalk\UavTalk\ReceiverActivity.cs
// UavTalk\UavTalk\RateDesired.cs
// UavTalk\UavTalk\PositionActual.cs
// UavTalk\UavTalk\PoiLocation.cs
// UavTalk\UavTalk\PathStatus.cs
// UavTalk\UavTalk\PathPlannerSettings.cs
// UavTalk\UavTalk\PathDesired.cs
// UavTalk\UavTalk\OveroSyncStats.cs
// UavTalk\UavTalk\OveroSyncSettings.cs
// UavTalk\UavTalk\OPLinkStatus.cs
// UavTalk\UavTalk\OPLinkSettings.cs
// UavTalk\UavTalk\ObjectPersistence.cs
// UavTalk\UavTalk\NEDPosition.cs
// UavTalk\UavTalk\NedAccel.cs
// UavTalk\UavTalk\ModuleSettings.cs
// UavTalk\UavTalk\MixerStatus.cs
// UavTalk\UavTalk\MixerSettings.cs
// UavTalk\UavTalk\ManualControlSettings.cs
// UavTalk\UavTalk\ManualControlCommand.cs
// UavTalk\UavTalk\Magnetometer.cs
// UavTalk\UavTalk\MagBias.cs
// UavTalk\UavTalk\INSState.cs
// UavTalk\UavTalk\INSSettings.cs
// UavTalk\UavTalk\I2CVMUserProgram.cs
// UavTalk\UavTalk\I2CVM.cs
// UavTalk\UavTalk\I2CStats.cs
// UavTalk\UavTalk\HwSparky.cs
// UavTalk\UavTalk\HwRevoMini.cs
// UavTalk\UavTalk\HwRevolution.cs
// UavTalk\UavTalk\HwQuanton.cs
// UavTalk\UavTalk\HwFreedom.cs
// UavTalk\UavTalk\HwFlyingF4.cs
// UavTalk\UavTalk\HwFlyingF3.cs
// UavTalk\UavTalk\HwDiscoveryF4.cs
// UavTalk\UavTalk\HwCopterControl.cs
// UavTalk\UavTalk\HomeLocation.cs
// UavTalk\UavTalk\GyrosBias.cs
// UavTalk\UavTalk\Gyros.cs
// UavTalk\UavTalk\GroundTruth.cs
// UavTalk\UavTalk\GroundPathFollowerSettings.cs
// UavTalk\UavTalk\GPSVelocity.cs
// UavTalk\UavTalk\GPSTime.cs
// UavTalk\UavTalk\GPSSatellites.cs
// UavTalk\UavTalk\GPSPosition.cs
// UavTalk\UavTalk\GCSTelemetryStats.cs
// UavTalk\UavTalk\GCSReceiver.cs
// UavTalk\UavTalk\FlightTelemetryStats.cs
// UavTalk\UavTalk\FlightStatus.cs
// UavTalk\UavTalk\FlightPlanStatus.cs
// UavTalk\UavTalk\FlightPlanSettings.cs
// UavTalk\UavTalk\FlightPlanControl.cs
// UavTalk\UavTalk\FlightBatteryState.cs
// UavTalk\UavTalk\FlightBatterySettings.cs
// UavTalk\UavTalk\FixedWingPathFollowerStatus.cs
// UavTalk\UavTalk\FixedWingPathFollowerSettingsCC.cs
// UavTalk\UavTalk\FixedWingPathFollowerSettings.cs
// UavTalk\UavTalk\FixedWingAirspeeds.cs
// UavTalk\UavTalk\FirmwareIAPObj.cs
// UavTalk\UavTalk\FaultSettings.cs
// UavTalk\UavTalk\CameraStabSettings.cs
// UavTalk\UavTalk\CameraDesired.cs
// UavTalk\UavTalk\BaroAltitude.cs
// UavTalk\UavTalk\BaroAirspeed.cs
// UavTalk\UavTalk\AttitudeSimulated.cs
// UavTalk\UavTalk\AttitudeSettings.cs
// UavTalk\UavTalk\AttitudeActual.cs
// UavTalk\UavTalk\AltitudeHoldSettings.cs
// UavTalk\UavTalk\AltitudeHoldDesired.cs
// UavTalk\UavTalk\AltHoldSmoothed.cs
// UavTalk\UavTalk\AirspeedSettings.cs
// UavTalk\UavTalk\AirspeedActual.cs
// UavTalk\UavTalk\ADCRouting.cs
// UavTalk\UavTalk\ActuatorSettings.cs
// UavTalk\UavTalk\ActuatorDesired.cs
// UavTalk\UavTalk\ActuatorCommand.cs
// UavTalk\UavTalk\AccessoryDesired.cs
// UavTalk\UavTalk\Accels.cs
