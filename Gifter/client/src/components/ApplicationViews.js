import React from "react";
import { Switch, Route } from "react-router-dom";
import PostList from "./PostList";
import PostForm from "./PostForm";
import UserPosts from "./UserPosts";

const ApplicationViews = () => {
  return (
    <Switch>
      <Route path="/login">
        <Login />
      </Route>

      <Route path="/register">
        <Register />
      </Route>

      <Route path="/" exact>
        <PostList />
      </Route>

      <Route path="/posts/add">
        <PostForm />
      </Route>

      <Route path="/posts/detail:id">
        <Post />
      </Route>

      <Route path="/users/:userId">
        <UserPosts />
      </Route>
    </Switch>
  );
};

export default ApplicationViews;
