/*
 * @file AdsbReceiver.cpp
 * @author Specific Atomics
 * @author Frank Poole
 * @date 2-21-16
 * @brief TODO make description
 */

#include "AdsbReceiver.h"

void AdsbReceiver::ReceiveReport(ClientSocket& client_socket) {
    AdsBReport adsb_report;
    client_socket >> adsb_report;
    PrintReport(adsb_report);
    std::cout << std::endl;
}

void AdsbReceiver::PrintReport(AdsBReport& adsb_report) {
    std::cout << "Received ADS-B Report" << std::endl;
    std::cout << "Timestamp: " << adsb_report.timestamp() << std::endl;
    std::cout << "Latitude: " << adsb_report.latitude() << std::endl;
    std::cout << "Longitude: " << adsb_report.longitude() << std::endl;
    std::cout << "Altitude: " << adsb_report.altitude() << std::endl;
    std::cout << "Tail Number: " << adsb_report.tail_number() << std::endl;
    std::cout << "North Velocity: " << adsb_report.north() << std::endl;
    std::cout << "East Velocity: " << adsb_report.east() << std::endl;
    std::cout << "Down Velocity: " << adsb_report.down() << std::endl;
}
