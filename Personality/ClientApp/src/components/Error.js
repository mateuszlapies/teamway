import {Toast, ToastBody, ToastHeader} from "reactstrap";
import {ErrorContext} from "../contexts/ErrorContext";

export default function Error() {
  return (
    <ErrorContext.Consumer>
      {(message) => (
        <Toast>
          <ToastHeader>Error</ToastHeader>
          <ToastBody>
            {message}
          </ToastBody>
        </Toast>
      )}
    </ErrorContext.Consumer>
  )
}