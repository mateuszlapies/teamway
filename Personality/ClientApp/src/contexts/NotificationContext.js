import {createContext, useCallback, useContext, useEffect, useState} from "react";
import Notification from "../components/Notification";

const NotificationContext = createContext(undefined);

export function useNotificationContext() {
  return useContext(NotificationContext);
}

export function ErrorContextProvider(props) {
  const [notifications, setNotifications] = useState([]);

  useEffect(() => {
    if (notifications.length > 0) {
      const timer = setTimeout(() =>
          setNotifications(previous => previous.slice(1))
      , 2500);
      return () => clearTimeout(timer);
    }
  }, [notifications]);

  const addNotification = useCallback((type, message) => {
    let notification = {...type, message: message}
    setNotifications(previous => [...previous, notification]);
  }, [setNotifications])

  return (
    <NotificationContext.Provider value={addNotification}>
      {props.children}
      <div className="position-absolute notifications">
        {notifications.map((notification, index) => (
          <Notification key={index} notification={notification}/>
        ))}
      </div>
    </NotificationContext.Provider>
  )
}