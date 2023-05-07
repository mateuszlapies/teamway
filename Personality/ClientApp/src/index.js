import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';

import './index.css';
import {ErrorContextProvider} from "./contexts/NotificationContext";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') ?? '';
const rootElement = document.getElementById('root') ?? document.documentElement;
const root = createRoot(rootElement);

root.render(
  <BrowserRouter basename={baseUrl}>
    <ErrorContextProvider>
      <App />
    </ErrorContextProvider>
  </BrowserRouter>
);

serviceWorkerRegistration.unregister();
reportWebVitals();
