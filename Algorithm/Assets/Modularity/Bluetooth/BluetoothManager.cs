//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using UnityEngine;

//enum States
//{
//    none,
//    scan,
//    connect,
//    subscribe,
//    unsubscribe,
//    disconnect
//}

//public class BluetoothManager : MonoBehaviour
//{
//    public static float distance;

//    [SerializeField]
//    private string connectDevice = "";
//    private string BLEAddress;
//    private string BLEServiceUUID;
//    private string BLECharacteristicUUID;

//    private States state;
//    private float timer;
//    private float scanTimer;

//    void Start()
//    {
//        InitBLE();
//    }

//    void Update()
//    {
//        if (timer > 0f)
//        {
//            timer -= Time.deltaTime;

//            if (timer <= 0f)
//            {

//                timer = 0f;

//                switch (state)
//                {
//                    case States.none:
//                        break;
//                    case States.scan:
//                        ScanBLE();
//                        break;
//                    case States.connect:
//                        ConnectBLE();
//                        break;
//                    case States.subscribe:
//                        SubscribeBLE();
//                        break;
//                    case States.unsubscribe:
//                        UnSubscribeBLE();
//                        break;
//                    case States.disconnect:
//                        DisconnectBLE();
//                        break;
//                }

//            }
//        }
//    }

//    private void SetState(States currentState, float limitTimer)
//    {
//        state = currentState;
//        timer = limitTimer;
//    }
    
//    // 블루투스 연결
//    private void InitBLE()
//    {
//        state = States.none;

//        BluetoothLEHardwareInterface.Initialize(true, false, () =>
//        {

//            SetState(States.scan, 0.1f);

//        }, (error) =>
//        {

//            if (error.Contains("Bluetooth LE Not Enabled"))
//            {
//                BluetoothLEHardwareInterface.BluetoothEnable(true);
//            }

//        });
//    }

//    // 블루투스 활성화관련
//    private void ScanBLE()
//    {
//        BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (address, deviceName) =>
//        {

//            if (deviceName.Contains (connectDevice))
//            {

//                BluetoothLEHardwareInterface.StopScan();

//                BLEAddress = address;

//                SetState(States.connect, 0.5f);

//            }

//        }, null, true);
//    }

//    // 블루투스 연결
//    private void ConnectBLE()
//    {
//        BluetoothLEHardwareInterface.ConnectToPeripheral(BLEAddress, null, null, (address, serviceUUID, characteristicUUID) =>
//        {

//            BLEServiceUUID = serviceUUID;
//            BLECharacteristicUUID = characteristicUUID;

//            SetState(States.subscribe, 3f);

//        }, (disconnectedAddress) => 
//        {

//            SetState(States.scan, 3f);
                    
//        });
//    }

//    // 블루투스 연결완료 데이터 수신 및 수신값 변환
//    private void SubscribeBLE()
//    {
//        BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(BLEAddress, BLEServiceUUID, BLECharacteristicUUID, null, (address, characteristicUUID, bytes) =>
//        {

//            string data = Encoding.UTF8.GetString(bytes);
//            string dt = data.Substring(0, 4);
//            string it = data.Substring(4);

//            distance = (float)Math.Round(Convert.ToInt32(dt, 16) * 0.001f, 1);

//        });
//    }

//    // 연결된 블루투스에서 값 전달받는것을 해제할때 사용
//    // public 사용추천
//    private void UnSubscribeBLE()
//    {
//        BluetoothLEHardwareInterface.UnSubscribeCharacteristic(BLEAddress, BLEServiceUUID, BLECharacteristicUUID, null);
//        SetState(States.disconnect, 2f);
//    }

//    // 블루투스 연결 해제
//    private void DisconnectBLE()
//    {
//        BluetoothLEHardwareInterface.DisconnectPeripheral(BLEAddress, null);

//        BluetoothLEHardwareInterface.DeInitialize(() =>
//        {

//            state = States.none;

//        });
//    }
//}
