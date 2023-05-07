import {Toast, ToastBody, ToastHeader} from "reactstrap";

export default function Notification(props) {
  return (
    <Toast className="mb-2">
      <ToastHeader>{props.notification.title}</ToastHeader>
      <ToastBody>
        {props.notification.message}
      </ToastBody>
    </Toast>
  )
}