import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link, useParams } from "react-router-dom";

const Post = ({ post }) => {
  const { id, userId } = useParams();
  return (
    <Card className="m-4">
      <p className="text-left px-2">
        Posted by:
        {userId ? (
          `${post.userProfile.name}`
        ) : (
          <Link to={`/users/${post.UserProfileId}`}>
            {`${post.userProfile?.name}`}
          </Link>
        )}
      </p>
      <CardImg top src={post.imageUrl} alt={post.title} />
      <CardBody>
        {id ? (
          <p>
            {" "}
            <strong>{post.title}</strong>
          </p>
        ) : (
          <Link to={`/posts/${post.id}`}>
            <strong>{post.title}</strong>
          </Link>
        )}
        <p>{post.caption}</p>
      </CardBody>
    </Card>
  );
};

export default Post;
