import {createContext, useCallback, useContext, useEffect, useState} from "react";
import {Toast, ToastBody, ToastHeader} from "reactstrap";

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
      , 2000);
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
          <Toast key={index} className="mb-2">
            <ToastHeader>{notification.title}</ToastHeader>
            <ToastBody>
              {notification.message}
            </ToastBody>
          </Toast>
        ))}
      </div>
    </NotificationContext.Provider>
  )
}