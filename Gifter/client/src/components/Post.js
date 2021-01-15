import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";

const Post = ({ post }) => {
  return (
    <Card className="m-4">
      <p className="text-left px-2">Posted by: {post.userProfile.Name}</p>
      <CardImg top src={post.imageUrl} alt={post.title} />
      <CardBody>
        <p>
          <Link to={`/posts/detail${post.id}`}>
            {/* {`/animals/detail/${animal.id}`}> */}
            <strong>{post.title}</strong>
          </Link>
        </p>
        <p>{post.caption}</p>
      </CardBody>
    </Card>
  );
};

export default Post;
