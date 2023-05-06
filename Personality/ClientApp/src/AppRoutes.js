import Home from "./components/Home";
import Test from "./components/Test";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/test',
    element: <Test />
  },
  {
    path: '/result/:id'
  }
];

export default AppRoutes;